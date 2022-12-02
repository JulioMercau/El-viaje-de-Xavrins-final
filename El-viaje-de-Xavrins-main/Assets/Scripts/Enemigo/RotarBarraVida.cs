using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarBarraVida : MonoBehaviour
{
    private GameObject cam;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Update()
    {
        this.transform.rotation = Quaternion.LookRotation(cam.transform.position - transform.position);
    }
}
