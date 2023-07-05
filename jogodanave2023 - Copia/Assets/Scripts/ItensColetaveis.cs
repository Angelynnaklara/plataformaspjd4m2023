using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensColetaveis : MonoBehaviour
{ 
    public bool ItemDeEscudo;
    public bool ItemDeLaserDuplo;
    public bool ItemDeVida;
    public int vidaParaDar;

 void OnTriggerEnter2D(Collider2D other)
 {
    if(other.gameObject.CompareTag("Player"))
    {
        if(ItemDeEscudo==true)
        {
           other.gameObject.GetComponent<VidaDoJogador>().AtivarEscudo();
        }
        if(ItemDeLaserDuplo==true)
        {
            other.gameObject.GetComponent<ControleDoJogador>().temLaserDuplo=false;
            other.gameObject.GetComponent<ControleDoJogador>().tempoAtualDosLasersDuplos=other.gameObject.GetComponent<ControleDoJogador>().tempoMaximoEntreOsLasersDuplos;
            other.gameObject.GetComponent<ControleDoJogador>().temLaserDuplo=true;
        }
        if(ItemDeVida ==true)
        {
           other.gameObject.GetComponent<VidaDoJogador>().GanharVida(vidaParaDar);
        }
        Destroy(this.gameObject);
    }

 }

}
