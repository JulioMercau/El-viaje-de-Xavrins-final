 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDePausa : MonoBehaviour
{

    public GameObject menuPausa;
    private bool estaPausado;
    
    
    // Start is called before the first frame update
    void Start()
    {
        menuPausa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaPausado == false)
            {
                Pausar();
            }
            else
            {
                Continuar();
            }
            
        }
    }

    
    public void Pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        estaPausado = true;

    }
    
    public void Continuar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1f;
        estaPausado = false;
    }

    public void MenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }



    public void Salir()

    {

        Application.Quit();
    }
}
