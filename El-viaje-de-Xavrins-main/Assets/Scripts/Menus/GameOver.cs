using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class GameOver : MonoBehaviour
{

    public GameObject gameOverCanvas;
    public GameObject filtroDeColor;
    public ControlDeVida vida;
    public GameObject uiNivel;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.SetActive(false);
        filtroDeColor.SetActive(false);
       

    }

    // Update is called once per frame
    void Update()
    {
        if (vida.muerto)
        {
            StartCoroutine("Muerte");

        }
    }

    IEnumerator Muerte()
    {
        yield return new WaitForSecondsRealtime(5.0f);
        
        uiNivel.SetActive(false);
        gameOverCanvas.SetActive(true);
        filtroDeColor.SetActive(true);
    }

    

    public void Reiniciar()
    {
        SceneManager.LoadScene("nivel_1");
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
