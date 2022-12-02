using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punio : MonoBehaviour
{
    // Area de daño Mano
    private GameObject punio;

    void Start()
    {
        punio = GameObject.FindGameObjectWithTag("ManoEnemigo2");
    }

    void Update()
    {
        transform.position = punio.transform.position;
        transform.rotation = punio.transform.rotation;
        transform.Rotate(0, 90, 0);
    }
}
