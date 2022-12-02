using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caja : MonoBehaviour
{
    
    public Image mensajeCaja;
    
    public bool rangoAccion;
    public Animator cajaAnimator;

    public bool cajaAbierta;
    

    

    void Start()
    {
        mensajeCaja.enabled = false;
        rangoAccion = false;
        cajaAbierta = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && rangoAccion)
        {
            mensajeCaja.enabled = false;
            cajaAbierta = true;
            cajaAnimator.SetTrigger("AbrirCaja");

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Principal") && !cajaAbierta)
        {
            mensajeCaja.enabled = true;
            rangoAccion = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Principal"))
        {
            mensajeCaja.enabled = false;
            rangoAccion = false;
        }

        
    }

}
