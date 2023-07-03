using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaDoJogador : MonoBehaviour
{
     public Slider barraDeVidaDoJogador;
     public int vidaMaximaDoJogador;
     public GameObject EscudoDoJogador;

    public int vidaAtualDoJogador;
    public int vidaMaximaDoEscudo;
    public int vidaAtualDoEscudo;

    public bool temEscudo;
    // Start is called before the first frame update
    void Start()
    {
         vidaAtualDoJogador =vidaMaximaDoJogador;
         barraDeVidaDoJogador.maxValue=vidaMaximaDoJogador;
         barraDeVidaDoJogador.value=vidaAtualDoJogador;

         EscudoDoJogador.SetActive(false);
         temEscudo= false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AtivarEscudo()
    {
      vidaAtualDoEscudo=vidaMaximaDoEscudo;
      EscudoDoJogador.SetActive(true);
      temEscudo= true;
    }

      public void MachucarJogador(int danoParaReceber)
    {

      if(temEscudo == false)
      {
        vidaAtualDoJogador -=danoParaReceber;
        barraDeVidaDoJogador.value=vidaAtualDoJogador;

        if(vidaAtualDoJogador<=0)
        {
          Debug.Log("Game Over");
        }
      }
      else
      {
        vidaAtualDoEscudo-= danoParaReceber;
        if(vidaAtualDoEscudo<= 0)
        {
          EscudoDoJogador.SetActive(false);
          temEscudo=false;
        }
      }
    }
}