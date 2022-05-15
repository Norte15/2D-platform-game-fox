using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void __Bttn_LoadScene(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    public void __Bttn_Exit()
    {
        print("Salir del juego");
        Application.Quit();
    }
}
