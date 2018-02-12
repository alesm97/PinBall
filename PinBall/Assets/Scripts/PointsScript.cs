////////////////////////////////////////////
// Práctica: Pinball
// Alumno/a: Alejandro Segura Meléndez
// Curso: 2017/2018
// Fichero: PointsScript.cs
////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script encargado de sumar puntos cuando la bola colisione con ellos.
/// </summary>
public class PointsScript : MonoBehaviour
{
    public long points;

    private void OnCollisionEnter(Collision other)
    {
        GameManager.points += points;
    }
}