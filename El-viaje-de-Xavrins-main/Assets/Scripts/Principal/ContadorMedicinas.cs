using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContadorMedicinas : MonoBehaviour
{
    public ControlDeVida controlVida;

    public TMP_Text tm;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        tm.text = (""+controlVida.botellasEquipadas);
    }
}
