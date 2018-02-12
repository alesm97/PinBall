////////////////////////////////////////////
// Práctica: Pinball
// Alumno/a: Alejandro Segura Meléndez
// Curso: 2017/2018
// Fichero: BlockerTopScript.cs
////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script responsable del cierre de la pared del lanzador.
/// </summary>
public class BlockerTopScript : MonoBehaviour
{
    // Pared que se va a cerrar.
    public GameObject wall;

    private void OnTriggerEnter(Collider other)
    {
        Invoke("cerrar", .5f);
    }

    private void cerrar()
    {
        wall.SetActive(true);
    }
}