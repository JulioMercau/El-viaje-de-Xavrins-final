using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potenciadorSalto : MonoBehaviour
{


    public GameObject jugador;
    private ControlDelPersonaje controlador;
    
    // Start is called before the first frame update
    void Start()
    {
       controlador = jugador.GetComponent<ControlDelPersonaje>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Principal")){

            controlador.alturaDelSalto = 35f;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("Principal"))
        {

            controlador.alturaDelSalto = 7f;

        }
    }
}
