using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medicina : MonoBehaviour
{
    private GameObject botella;
    public Image mensajeItem;
    public Animator botellaAnimator;
    public ControlDeVida controlVida;
    public Caja caja;
    public bool rangoAccion;
    public Animator principalAnimator;
    public int WaitForSeconds { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        botella = GameObject.FindGameObjectWithTag("Caja");
        transform.position = botella.transform.position;
        transform.rotation = botella.transform.rotation;
        mensajeItem.enabled = false;
        rangoAccion = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (caja.cajaAbierta)
        {
            new WaitForSeconds(1);
            botellaAnimator.SetTrigger("Subir");

        }

        if (Input.GetButtonDown("Fire2") && rangoAccion & caja.cajaAbierta && !caja.mensajeCaja.enabled)
        {
            mensajeItem.enabled = false;
            controlVida.botellasEquipadas += 1;
            
            Esconder();
        }
    }

    

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Principal") && caja.cajaAbierta)
        {
            mensajeItem.enabled = true;
            rangoAccion = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Principal")&& caja.cajaAbierta)
        {
            mensajeItem.enabled = false;
            rangoAccion = false;
            
        }
    }

    public void Esconder()
    {
        botella = GameObject.FindGameObjectWithTag("Esconder");
        transform.position = botella.transform.position;
        transform.rotation = botella.transform.rotation;
    }


}
