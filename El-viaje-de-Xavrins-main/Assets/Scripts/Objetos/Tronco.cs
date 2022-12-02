using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tronco : MonoBehaviour
{
    // Ancla el tronco a la mano del enemigo
    private GameObject tronco;
    

    void Start()
    {
        tronco = GameObject.FindGameObjectWithTag("ManoEnemigo");

    }

    void Update()
    {
        transform.position = tronco.transform.position;
        transform.rotation = tronco.transform.rotation;
        transform.Rotate(230, 60, 0);
    }
}
