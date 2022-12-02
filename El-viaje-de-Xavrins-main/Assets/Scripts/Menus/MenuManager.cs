using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //retarda una accion los segundos indicados
    IEnumerator CargaNivel()
    {
        yield return new WaitForSecondsRealtime (2.0f);
        SceneManager.LoadScene("nivel_1");
    }

    IEnumerator SalirDelJuego()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        Application.Quit();
    }

    public void CargaEscena()
    {


        StartCoroutine("CargaNivel");
        

    }

    public void Salir()
    {
        StartCoroutine("SalirDelJuego");
        
    }
}
