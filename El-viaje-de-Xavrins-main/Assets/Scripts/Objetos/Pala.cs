using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pala : MonoBehaviour
{
    // Ancla la pala a la mano
    private GameObject pala;
    
    void Start()
    {
        pala = GameObject.FindGameObjectWithTag("ManoDerecha");
    }

    void Update()
    {
        transform.position = pala.transform.position;
        transform.rotation = pala.transform.rotation;
        transform.Rotate(0, 90, 180);
    }
    
    
}
