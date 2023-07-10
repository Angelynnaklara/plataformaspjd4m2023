using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    public GameObject efeitoDeExplosao;
    public float velocidadeDoInimigo;
    public int vidaMaximaDoInimigo;
    public int vidaAtualDoInimigo;
    public int pontosParaDar;
    public int chanceParaDropar;
    public GameObject laserDoInimigo;
    public Transform localDoDisparo;
    public GameObject itemParaDropar;
    public float velocidadeDoInimigos;
    public float tempoMaximoEntreOsLasers;
    public float tempoAtualDosLasers;
    public bool inimigoAtirador;
    public bool inimigoAtivado;
    public int danoDaNave;


    // Start is called before the first frame update
    void Start()
    {
        inimigoAtivado = false;

        vidaAtualDoInimigo = vidaMaximaDoInimigo;
    }

    // Update is called once per frame
    void Update()
    {
        MoviventarInimigo();
        
        if (inimigoAtirador== true && inimigoAtivado == true)
        {
           
            AtirarLaser();
        }
    }
    public void AtivarInimigo()
    {
        inimigoAtivado = true;
    }

    public void AtivarInimigo()
    {
     inimigoAtivado = true;
    }

          private void MoviventarInimigo()
          {
            transform.Translate(Vector3.down * velocidadeDoInimigo *Time.deltaTime);
          }
    
          private void AtirarLaser()
    {
        tempoAtualDosLasers -= Time.deltaTime;
        if (tempoAtualDosLasers <=0)
        {
            Instantiate(laserDoInimigo, localDoDisparo.position, Quaternion.Euler(0f, 0f, 90f));
            tempoAtualDosLasers = tempoMaximoEntreOsLasers;
        }
    }
    //quando a vida do inimigo for igual a 0 ele ira se destruir.
    public void MachucarInimigo(int danoPraraReceber)
    {
        vidaAtualDoInimigo -=danoPraraReceber;
        if(vidaAtualDoInimigo <= 0)
        {
            GameManager.instance.AumentarPontuacao(pontosParaDar);
            Instantiate(efeitoDeExplosao, transform.position, transform.rotation);
            EfeitosSonoros.instance.somDaExplosao.Play();

          int numeroAleatorio=Random.Range(0,100);
          if(numeroAleatorio<= chanceParaDropar)
          {
            Instantiate(itemParaDropar,transform.position,Quaternion.Euler(0f,0f,0f));
          }

            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Player"))
        {
            collisionInfo.gameObject.GetComponent<VidaDoJogador>().MachucarJogador(danoDaNave);
            Instantiate(efeitoDeExplosao, transform.position, transform.rotation);
            EfeitosSonoros.instance.somDaExplosao.Play();

            Destroy(this.gameObject);
        }
    }
}
