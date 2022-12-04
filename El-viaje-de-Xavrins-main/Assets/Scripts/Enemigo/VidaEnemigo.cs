using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigo : MonoBehaviour
{
    [Header("Objetos")]
    public Animator enemigoAnimator;
    public ControlMovimientoEnemigo enemigoController;
    public Slider barraDeVidaEnemigo;
    public ControlDelPersonaje ataquePrincipal;
    public ControlDeVida vidaPrincipal;
    public GameObject nubes;

    [Header("Variables")]
    public int danioRecibido;
    int vidaEnemigo;
    public bool puedeRecibirDanio;
    public bool puedeMoverse;
    
    void Start()
    {
        vidaEnemigo = 100;
        puedeRecibirDanio = true;
        puedeMoverse = true;
        danioRecibido = 15;
    }

    void Update()
    {
        barraDeVidaEnemigo.value = vidaEnemigo;
        if (vidaPrincipal.salud == 0)
        {
            puedeMoverse = false;
        }
        if (!enemigoController.estaAtacando)
        {
            puedeRecibirDanio = true;
        }
    }

    public void RecibirDanio()
    {
        if (vidaEnemigo > 0)
        {
            vidaEnemigo -= (Mathf.Min(vidaEnemigo,danioRecibido));
        }
        if (vidaEnemigo == 0)
        {
            StartCoroutine(SecuenciaMuerte());
        }
    }

    public void Reanudar()
    {
        enemigoController.estaAtacando = false;
    }

    public void InicioDañoEnemigo()
    {
        puedeRecibirDanio = false;
        RecibirDanio();
    }

    public void FinDañoEnemigo()
    {
        puedeRecibirDanio = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ArmaPrincipal") && ataquePrincipal.puedeDaniar)
        {
            if (puedeRecibirDanio)
            {
                enemigoAnimator.SetTrigger("Daño");
            }
        }
    }
    IEnumerator SecuenciaMuerte()
    {
        enemigoAnimator.SetTrigger("Muere");
        puedeRecibirDanio = false;
        puedeMoverse = false;
        enemigoController.produceDanio = false;
        yield return new WaitForSecondsRealtime(1.5f);
        nubes = Instantiate(nubes.gameObject, transform.position, transform.rotation);
        yield return new WaitForSecondsRealtime(0.75f);
        Destroy(nubes.gameObject);
        Destroy(this.gameObject);
        yield return null;
    }
}
