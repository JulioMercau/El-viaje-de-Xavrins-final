using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigo2 : MonoBehaviour
{
    int vidaEnemigo;
    public bool puedeRecibirDanio;
    public bool puedeMoverse;
    public Animator enemigoAnimator;
    public ControlMovimientoEnemigo2 enemigoController;
    public Slider barraDeVidaEnemigo;
    public ControlDelPersonaje ataquePrincipal;
    public ControlDeVida vidaPrincipal;
    public int danioRecibido;

    void Start()
    {
        vidaEnemigo = 100;
        puedeRecibirDanio = true;
        puedeMoverse = true;
        danioRecibido = 40;
    }

    void Update()
    {
        barraDeVidaEnemigo.value = vidaEnemigo;
        if (vidaPrincipal.salud == 0)
        {
            puedeMoverse = false;
        }
    }

    public void RecibirDanio()
    {
        if (vidaEnemigo > 0)
        {
            vidaEnemigo -= (Mathf.Min(vidaEnemigo, danioRecibido));
        }
        if (vidaEnemigo == 0)
        {
            enemigoAnimator.SetTrigger("Muere");
            puedeRecibirDanio = false;
            puedeMoverse = false;
            enemigoController.produceDanio = false;
        }
    }

    public void Reanudar()
    {
        enemigoController.estaAtacando = false;
    }

    public void InicioDa�oEnemigo()
    {
        puedeRecibirDanio = false;
        RecibirDanio();
    }

    public void FinDa�oEnemigo()
    {
        puedeRecibirDanio = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ArmaPrincipal") && ataquePrincipal.puedeDaniar)
        {
            if (puedeRecibirDanio)
            {
                enemigoAnimator.SetTrigger("Da�o");
            }
        }
    }
}
