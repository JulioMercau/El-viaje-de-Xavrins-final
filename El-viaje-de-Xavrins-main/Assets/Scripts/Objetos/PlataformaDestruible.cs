using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDestruible : MonoBehaviour
{

    public GameObject plataforma;
   
    
    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestruirPlataforma()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        plataforma.SetActive(false);
        
       
    }


    IEnumerator RestituirPlataforma()
    {
        yield return new WaitForSecondsRealtime(4.0f);
        plataforma.SetActive(true);
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Principal"))
        {
            StartCoroutine("DestruirPlataforma");
            StartCoroutine("RestituirPlataforma");
        }
    }

   

    
       
}
