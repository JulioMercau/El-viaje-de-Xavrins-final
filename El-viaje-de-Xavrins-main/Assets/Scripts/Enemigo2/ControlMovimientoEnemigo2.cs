using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMovimientoEnemigo2 : MonoBehaviour
{
    [Header("Variables de Movimiento")]
    public float rangoDeVision;
    public string variableMovimiento;
    public float velocidadMovimiento;
    public LayerMask capaDelJugador;
    public Transform jugador;
    bool estaAlerta;
    public Animator enemigoAnimator;
    public VidaEnemigo2 vidaEnemigo;

    [Header("Variables de Ataque")]
    bool enRangoAtaque;
    public float rangoAtaque;
    public bool produceDanio;
    public bool estaAtacando;


    [Header("Variables del ModoPatrulla")]
    public int rutina;
    float cronometro;
    Quaternion angulo;
    float grado;

    void Start()
    {
        estaAlerta = false;
        estaAtacando = false;
        enRangoAtaque = false;
        produceDanio = false;
    }

    void Update()
    {
        if (vidaEnemigo.puedeMoverse)
        {
            if (!estaAlerta)
            {
                Patrullaje();
            }
            estaAlerta = Physics.CheckSphere(transform.position, rangoDeVision, capaDelJugador);
            enRangoAtaque = Physics.CheckSphere(transform.position, rangoAtaque, capaDelJugador);
            enemigoAnimator.SetFloat(variableMovimiento, 0);
            if (estaAlerta)
            {
                Vector3 posicionJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
                transform.LookAt(posicionJugador);
                if (!enRangoAtaque && !estaAtacando)
                {
                    transform.position = Vector3.MoveTowards(transform.position, posicionJugador, velocidadMovimiento * Time.deltaTime);
                    enemigoAnimator.SetFloat(variableMovimiento, 1);
                }
            }
            if (enRangoAtaque)
            {
                enemigoAnimator.SetFloat(variableMovimiento, 0);
                if (!estaAtacando)
                {
                    enemigoAnimator.SetTrigger("Ataque");
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeVision);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangoAtaque);
    }

    public void Patrullaje()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;
        }
        switch (rutina)
        {
            case 0:
                enemigoAnimator.SetBool("EstaPatrullando", false);
                break;
            case 1:
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina++;
                break;
            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * (velocidadMovimiento / 2) * Time.deltaTime);
                enemigoAnimator.SetBool("EstaPatrullando", true);
                break;
        }
    }

    public void InicioAtaque()
    {
        estaAtacando = true;
    }

    public void ProducirDanio()
    {
        produceDanio = true;
    }

    public void NoProducirDanio()
    {
        produceDanio = false;
        vidaEnemigo.puedeRecibirDanio = true;
    }

    public void FinAtaque()
    {
        estaAtacando = false;
    }
}
