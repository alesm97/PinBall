////////////////////////////////////////////
// Práctica: Pinball
// Alumno/a: Alejandro Segura Meléndez
// Curso: 2017/2018
// Fichero: InterfaceScript.cs
////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script encargado de modificar los textos del UI de la escena 'Pinball'.
/// </summary>
public class InterfaceScript : MonoBehaviour
{
    // Referencia al texto de los puntos.
    public Text pointsText;

    // Referencia al texto de las vidas.
    public Text lifesText;

    // Update is called once per frame
    void Update()
    {
        pointsText.text = String.Format("Points: {0}", GameManager.points);
        lifesText.text = String.Format("Lifes: {0}", GameManager.lifes);
    }
}