using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    public GameObject heartPrefab;
    public Player player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        VidasIniciales();
    }

    private void VidasIniciales()
    {
        for (int i = player.vida; i > 0; i--)
        {
            GenerarVidasIniciales();
        }
    }

    public void GenerarVidasIniciales()
    {
         GameObject corazon = Instantiate(heartPrefab, Vector3.zero, Quaternion.identity);
        corazon.transform.SetParent(transform);
        corazon.gameObject.name = "HeartIcon";
    }

    public void SumarVidas()
    {
        player.vida++;
        GameObject corazon = Instantiate(heartPrefab, Vector3.zero, Quaternion.identity);
        corazon.transform.SetParent(transform);
        corazon.gameObject.name = "HeartIcon";
    }

    public void QuitarVida()
    {
        player.vida--;
        Destroy(GameObject.Find("HeartIcon"));
        
    }

}
