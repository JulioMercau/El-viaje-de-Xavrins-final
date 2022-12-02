using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caja : MonoBehaviour
{
    [Header("Objetos")]
    public Animator cajaAnimator;
    public GameObject item;
    public GameObject particulas;
    public GameObject luzCaja;
    public ControlDeVida controlVida;
    public ControlDelPersonaje principal;

    [Header("Mensajes")]
    public Image mensajeCaja;
    public Image mensajeItem;

    [Header("Variables")]
    public bool rangoAccion;
    public bool cajaAbierta;
    bool hayItem;

    void Start()
    {
        mensajeCaja.enabled = false;
        mensajeItem.enabled = false;
        rangoAccion = false;
        cajaAbierta = false;
        hayItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && rangoAccion && !cajaAbierta)
        {
            mensajeCaja.enabled = false;
            cajaAbierta = true;
            cajaAnimator.SetTrigger("AbrirCaja");
            particulas = Instantiate(particulas.gameObject, transform.position, transform.rotation);
            particulas.transform.Rotate(-90, 0, 0);
            luzCaja = Instantiate(luzCaja.gameObject, transform.position, transform.rotation);
            luzCaja.transform.Rotate(-90, 0, 0);
        }
        if (Input.GetButtonDown("Fire2") && rangoAccion && cajaAbierta && hayItem)
        {
            mensajeItem.enabled = false;
            controlVida.botellasEquipadas += 1;
            StartCoroutine(SecuenciaDestruccion());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Principal") && !cajaAbierta)
        {
            mensajeCaja.enabled = true;
            rangoAccion = true;
            principal.puedeInteractuar = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Principal") && cajaAbierta)
        {
            mensajeItem.enabled = true;
            rangoAccion = true;
            principal.puedeInteractuar = true;
            if (!hayItem)
            {
                mensajeItem.enabled = false;
                rangoAccion = false;
                principal.puedeInteractuar = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Principal")&&!cajaAbierta)
        {
            mensajeCaja.enabled = false;
            rangoAccion = false;
            principal.puedeInteractuar = false;
        }

        if (other.CompareTag("Principal") && cajaAbierta)
        {
            mensajeItem.enabled = false;
            rangoAccion = false;
            principal.puedeInteractuar = false;
        }
    }

    private void InstanciarItem()
    {
        item = Instantiate(item.gameObject, transform.position, transform.rotation);
        hayItem = true;
    }

    IEnumerator SecuenciaDestruccion()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        Destroy(item.gameObject);
        Destroy(particulas.gameObject);
        Destroy(luzCaja.gameObject);
        hayItem = false;
        yield return null;
    }
}
