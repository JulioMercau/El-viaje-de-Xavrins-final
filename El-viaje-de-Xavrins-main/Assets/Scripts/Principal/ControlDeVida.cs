using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlDeVida : MonoBehaviour
{
    [Header("Objetos")]
    public Slider barraDeVida;
    public Animator principalAnimator;
    public ControlDelPersonaje principalControl;
    public GameObject botella;

    [Header("Variables")]
    public int salud;
    public int botellasEquipadas;
    public bool puedeRecibirDanio;
    public bool enemigoAtaca;
    public bool muerto;
    
    void Start()
    {
        salud = 100;
        botellasEquipadas = 0;
        puedeRecibirDanio = true;
        enemigoAtaca = false;
        muerto = false;
    }

    void Update()
    {
        barraDeVida.value = salud;
        
        if (Input.GetKeyDown("e") && botellasEquipadas>0 && salud<100)
        {
            UsarMedicina();
            principalAnimator.SetTrigger("Bebe");
        }

        if (salud == 0)
        {
            principalAnimator.SetTrigger("Muere");
            principalControl.puedeMoverse = false;
            puedeRecibirDanio = false;
            muerto = true;
        }
    }
    
    public void RestarSalud()
    {
        if (salud > 0)
        {
            salud -= Mathf.Min(salud,10);
        }
       
    }
    public void UsarMedicina()
    {
        salud += Mathf.Min((100 - salud), 30);
        botellasEquipadas -= 1;
    }

    //Animacion de daño
    public void RecibeDanio()
    {
        principalControl.puedeMoverse = false;
        puedeRecibirDanio = false;
        principalControl.puedeAtacar = false;
        RestarSalud();
    }
    
    public void DejaDeRecibirDanio()
    {
        principalControl.puedeMoverse = true;
        puedeRecibirDanio = true;
        principalControl.puedeAtacar = true;
    }

    //Usar Objeto
    public void InicioBebe()
    {
        botella = Instantiate(botella.gameObject);
        principalControl.puedeMoverse = false;
    }
    public void FinBebe()
    {
        Destroy(botella.gameObject);
        principalControl.puedeMoverse = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ArmaEnemigo"))
        {
            if(enemigoAtaca && puedeRecibirDanio)
            {
                principalAnimator.SetTrigger("RecibeDaño");
            }
        }
        if (other.CompareTag("ArmaEnemigo2"))
        {
            if (enemigoAtaca && puedeRecibirDanio)
            {
                principalAnimator.SetTrigger("RecibeDaño");
            }
        }
    }
}
