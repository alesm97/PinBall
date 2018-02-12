////////////////////////////////////////////
// Práctica: Pinball
// Alumno/a: Alejandro Segura Meléndez
// Curso: 2017/2018
// Fichero: FinalInterfaceScript.cs
////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script encargado de cambiar el texto de puntuación en la escena "Final".
/// </summary>
public class FinalInterfaceScript : MonoBehaviour
{
    // Referencia al texto (elemento UI).
    public Text score;

    void Start()
    {
        score.text = String.Format("Score: {0}", GameManager.points);
    }
}