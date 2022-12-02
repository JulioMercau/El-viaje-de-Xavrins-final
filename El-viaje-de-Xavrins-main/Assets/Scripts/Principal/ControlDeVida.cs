using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlDeVida : MonoBehaviour
{
    public Animator principalAnimator;
    public ControlDelPersonaje principalControl;
    public int salud;
    public int botellasEquipadas;
    public Slider barraDeVida;
    public bool puedeRecibirDanio;
    public ControlMovimientoEnemigo enemigo;
    public ControlMovimientoEnemigo2 enemigo2;
    public GameObject botella;
    void Start()
    {
        salud = 100;
        botellasEquipadas = 0;
        puedeRecibirDanio = true;
        
    }

    // Update is called once per frame
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

    public void InicioBebe()
    {
        botella = Instantiate(botella.gameObject);
    }
    public void FinBebe()
    {
        Destroy(botella.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ArmaEnemigo"))
        {
            if(enemigo.produceDanio && puedeRecibirDanio)
            {
                principalAnimator.SetTrigger("RecibeDaño");
            }
        }
        if (other.CompareTag("ArmaEnemigo2"))
        {
            if (enemigo2.produceDanio && puedeRecibirDanio)
            {
                principalAnimator.SetTrigger("RecibeDaño");
            }
        }
    }
}
