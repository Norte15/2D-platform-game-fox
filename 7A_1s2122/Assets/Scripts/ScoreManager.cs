using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text textoPuntuacion;
    public int puntuacionGlobal = 0;


    // Update is called once per frame
    void Update()
    {
        textoPuntuacion.text = "Puntuación: " + puntuacionGlobal.ToString();
    }

    public void SumarPuntuacion(int a)
    {
        puntuacionGlobal += a;
    }
}
