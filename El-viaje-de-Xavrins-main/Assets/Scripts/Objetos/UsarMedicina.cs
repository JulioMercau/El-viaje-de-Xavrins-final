using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsarMedicina : MonoBehaviour
{
    private GameObject manoIzq;

    
    // Start is called before the first frame update
    void Start()
    {
        manoIzq = GameObject.FindGameObjectWithTag("ManoIzquierda");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = manoIzq.transform.position;
        transform.rotation = manoIzq.transform.rotation;
        transform.Rotate(0, 90, 270);
    }

}
