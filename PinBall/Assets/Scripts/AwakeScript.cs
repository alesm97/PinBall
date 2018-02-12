////////////////////////////////////////////
// Práctica: Pinball
// Alumno/a: Alejandro Segura Meléndez
// Curso: 2017/2018
// Fichero: AwakeScript.cs
////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Según el botón que se pulse en la escena "Awake", se pasará a la siguiente escena o se saldrá de la aplicación.
/// </summary>
public class AwakeScript : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("Pinball");
    }

    public void exit()
    {
        Application.Quit();
    }
}