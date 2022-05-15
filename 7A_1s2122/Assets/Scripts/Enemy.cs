using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform rightLimit;
    public Transform leftLimit;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxColliderEnemy;
    public BoxCollider2D boxColliderKill;
    public Animator playerAnimator;
    public HeartManager heartManager;

    public float enemySpeed = 2.0f;
    public float playerImpulse = 8.0f;
    public float playerHit = 3.0f;

    public bool direccion = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
        heartManager = GameObject.Find("HeartPanel").GetComponent<HeartManager>();
    }


    private void Update()
    {
        EnemyMovement();



        if (playerAnimator.GetBool("isFalling") == true)
        {
            boxColliderEnemy.enabled = false;
            boxColliderKill.enabled = true;
        }
        else
        {
            boxColliderEnemy.enabled = true;
            boxColliderKill.enabled = false;
        }
    }

    void EnemyMovement()
    {
        if (direccion == true)
        {
            transform.Translate(Vector2.right * enemySpeed * Time.deltaTime);
            spriteRenderer.flipX = true;
        }
        else
        {

            transform.Translate(Vector2.left * enemySpeed * Time.deltaTime);
            spriteRenderer.flipX = false;
        }


        //Condicionales para que detecte los limites izquierda y derecha

        if (transform.position.x <= leftLimit.position.x)
        {
            direccion = true;
        }

        if (transform.position.x >= rightLimit.position.x)
        {
            direccion = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && boxColliderKill.enabled == true)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * playerImpulse, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<AudioPlayer>().ReproducirAudio(1);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player" && boxColliderEnemy.enabled == true)
        {
            
            if (direccion)
            {
                //Enemigo mira a la derecha
                heartManager.QuitarVida();
                collision.gameObject.GetComponent<Player>().personajeGolpeado = true;
                collision.gameObject.GetComponent<Player>().ResetearMovimiento1();
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2 (1 , 1) * playerHit, ForceMode2D.Impulse);
            }
            else
            {
                //Enemigo mira a la izquierda
                heartManager.QuitarVida();
                collision.gameObject.GetComponent<Player>().personajeGolpeado = true;
                collision.gameObject.GetComponent<Player>().ResetearMovimiento1();
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * playerHit, ForceMode2D.Impulse);
            }

            
           
        }
    }
}
