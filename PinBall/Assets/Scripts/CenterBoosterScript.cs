////////////////////////////////////////////
// Práctica: Pinball
// Alumno/a: Alejandro Segura Meléndez
// Curso: 2017/2018
// Fichero: CenterBoosterScript.cs
////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script encargado de congelar la bola en el centro, sumar los puntos, esperar un tiempo determinado y lanzarla en una dirección aleatoria.
/// </summary>
public class CenterBoosterScript : MonoBehaviour
{
    // Cantidad de puntos que se van a sumar.
    public long points;

    // Potencia que se va a imprimir.
    public float power;

    // Referencia a la bola.
    private GameObject ball;

    private void OnCollisionEnter(Collision other)
    {
        ball = other.gameObject;
        GetComponent<AudioSource>().Play();
        other.transform.position = new Vector3(0.1f, 0.1f, -1.2f);
        other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GameManager.points += points;
        Invoke("launch", 1.5f);
    }

    private void launch()
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        rb.AddForce(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * power);
    }
}