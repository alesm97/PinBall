////////////////////////////////////////////
// Práctica: Pinball
// Alumno/a: Alejandro Segura Meléndez
// Curso: 2017/2018
// Fichero: ChangeColor.cs
////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script encargado de cambiar el brillo de los objetos con los que impacta la bola.
/// </summary>
public class ChangeColor : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        GetComponent<MeshRenderer>().material.color *= 1.8f;
        GetComponent<AudioSource>().Play();
    }

    private void OnCollisionExit(Collision other)
    {
        GetComponent<MeshRenderer>().material.color /= 1.8f;
    }
}