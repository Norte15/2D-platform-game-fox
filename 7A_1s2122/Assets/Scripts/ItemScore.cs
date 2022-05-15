using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScore : MonoBehaviour
{

    public int scoreValue = 1;
    public ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.Find("TextScore").GetComponent<ScoreManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scoreManager.SumarPuntuacion(scoreValue);
            collision.gameObject.GetComponent<AudioPlayer>().ReproducirAudio(2);
            Destroy(gameObject);

        }
    }



}
