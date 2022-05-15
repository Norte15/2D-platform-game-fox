using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float temporizador = 60.0f;
    public Text textoTemporizador;

    private void Update()
    {
        temporizador -= Time.deltaTime;
        textoTemporizador.text = "Tiempo: " + temporizador.ToString("F0");

        if (temporizador <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
