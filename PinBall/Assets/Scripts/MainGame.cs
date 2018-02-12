////////////////////////////////////////////
// Práctica: Pinball
// Alumno/a: Alejandro Segura Meléndez
// Curso: 2017/2018
// Fichero: MainGame.cs
////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script encargado del funcionamiento principal del juego.
/// </summary>
public class MainGame : MonoBehaviour
{
    // Referencia a la bola inicial.
    public GameObject ball;

    // Referencia a las paredes que se han de modificar.
    public GameObject[] walls = new GameObject[2];

    // Referencia a la bola que se a generar.
    public GameObject nBall;

    // Referencia al clip de audio de fin de juego.
    public AudioClip finalSound;

    // Bandera para reproducir o no el sonido.
    private bool play = true;

    // Bandera para dar por finalizada la partida.
    private bool finished = false;

    // Referencia a la fuente de audio.
    private AudioSource _audioSource;


    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        // Si le hemos dado a jugar de nuevo, tenemos que poner los valores por defecto.
        GameManager.points = 0;
        GameManager.lifes = 5;
    }

    void Update()
    {
        // Si el juego no ha finalizado, seguimos.
        if (!finished)
        {
            // Si hay alguna vida, seguimos con la ejecución.
            if (GameManager.lifes > 0)
            {
                // Si la bola se ha caído suena el audio, la eliminamos y creamos una nueva.
                if (ball.transform.position.y < 0)
                {
                    if (play)
                    {
                        _audioSource.Play();
                        play = false;
                    }

                    GameManager.lifes--;
                    if (GameManager.lifes > 0)
                    {
                        Destroy(ball);
                        Invoke("newBall", 1);
                    }
                    else
                    {
                        Destroy(ball);
                    }
                }
            }
            // Si no hay vidas, damos el juego por terminado.
            else
            {
                finished = true;
                _audioSource.clip = finalSound;
                _audioSource.Play();
                Invoke("finalizar", 4f);
            }
        }
    }

    private void newBall()
    {
        // Creamos la nueva bola.
        ball = Instantiate(nBall);
        // La ponemos en el lanzador.
        ball.transform.position = new Vector3(3.2f, 0.11f, -4.2f);
        // Volvemos a poner invisibles las paredes.
        foreach (GameObject wall in walls)
        {
            wall.SetActive(false);
        }

        // Indicamos que se puede volver a rproducir el audio.
        play = true;
    }

    private void finalizar()
    {
        // Cargamos la escena final.
        SceneManager.LoadScene("Final");
    }
}