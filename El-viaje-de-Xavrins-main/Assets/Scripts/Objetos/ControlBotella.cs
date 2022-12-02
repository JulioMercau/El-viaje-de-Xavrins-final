using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBotella : MonoBehaviour
{
    bool rotar;
    bool subir;
    float velocidad = 120.0f;

    void Start()
    {
        rotar = false;
        subir = false;
        StartCoroutine(Comportamiento());
    }

    void Update()
    {
        if (subir)
        {
            if (transform.position.y < 3)
            {
                transform.Translate(Vector3.up*Time.deltaTime*2.5f);
            }
            if (transform.position.y >= 3)
            {
                rotar = true;
                subir = false;
            }
        }
        
        if (rotar)
        {
            transform.Rotate(0, velocidad * Time.deltaTime,0);
        }

    }



    IEnumerator Comportamiento()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        subir = true;
        yield return null;

    }
}
