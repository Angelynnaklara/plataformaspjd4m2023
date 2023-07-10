using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoJogador : MonoBehaviour
{
    public Rigidbody2D oRigidbody2D;
    public GameObject LaserDoJogador;
    public Transform localDoDisparoUnico;
    public Transform localDoDisparoDaDireita;
    public Transform localDoDisparoDaEsquerda;
    public float tempoMaximoEntreOsLasersDuplos;
    public float tempoAtualDosLasersDuplos;
    public float velocidadeDaNave;
    private Vector2 teclasApertadas;
    public bool temLaserDuplo;
    public bool jogadorEstaVivo;
    // Start is called before the first frame update
    void Start()
    {   
        temLaserDuplo=false;
        jogadorEstaVivo = true;
        tempoAtualDosLasersDuplos=tempoMaximoEntreOsLasersDuplos;
    }
    // Update is called once per frame
    void Update()
    {
        MovimentarJogador();
        if (jogadorEstaVivo == true)
        {
            AtirarLaser();
        }
        if(temLaserDuplo==true)
        {
          tempoAtualDosLasersDuplos-=Time.deltaTime;
          if(tempoAtualDosLasersDuplos<=0)
          {
             DesativarLaserDuplo();
          }
        }
    }
    private void  MovimentarJogador()
    {
        teclasApertadas = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        oRigidbody2D.velocity = teclasApertadas.normalized * velocidadeDaNave;
    }
    private void AtirarLaser()
    {
        
        if(Input.GetButtonDown("Fire1"))
        {
           if(temLaserDuplo==false)
           {
            Instantiate(LaserDoJogador,localDoDisparoUnico.position,localDoDisparoUnico.rotation);
           }
           else
           {
               Instantiate(LaserDoJogador, localDoDisparoDaEsquerda.position,localDoDisparoDaEsquerda.rotation);
                 Instantiate(LaserDoJogador, localDoDisparoDaDireita.position,localDoDisparoDaDireita.rotation);
           }
            EfeitosSonoros.instance.somDoLaserDoJogador.Play();
        }
    }
    
        private void DesativarLaserDuplo()
    {
      temLaserDuplo=false;
      tempoAtualDosLasersDuplos=tempoMaximoEntreOsLasersDuplos;
    }
}
