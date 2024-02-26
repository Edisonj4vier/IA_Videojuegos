using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaludPlayer : MonoBehaviour
{
    public float salud = 100f;
    public float saludMax = 100f;
    [Header("Interfaz")]
    public Image barraSalud;
    public Text textoSalud;

    private void Update()
    {
        ActualizarSalud();
    }
    
    void ActualizarSalud()
    {
        barraSalud.fillAmount = salud / saludMax;
        textoSalud.text = "Salud: " + salud.ToString("f0");
    }
}
