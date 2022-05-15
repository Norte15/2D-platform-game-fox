using UnityEngine;
using UnityEngine.SceneManagement;

//Input.GetKey >> registra el uso de las teclas
// Input.GetKey (KeyCode.Space)
//Input.GetButton >> registra el uso de botones (pero tambien teclas)
//Input.GetAxis >> regisra las flechitas ( izquierda, derecha, etc.)
//Input.MouseButton >> registra el uso del raton

//Diferentes tipos de registros:
//--GetKey >> tipo estandar, registra cada frame en el que la tecla esta pulsada
//--GetKeyDown >> cuando se pulsa la tecla, solo en el momento de pulsarse
//--GetKeyUp >> registra cuando levantamos el dedo de una tecla 

public class Player : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public float velocidad = 3.0f;
    private float velocidadOriginal;
    public float velocidadAumentada = 5.0f;
    public SpriteRenderer playerSpriteRenderer;
    public float impulso = 5.0f;

    public int vida = 3;

    public Animator playerAnimator;
    public AudioPlayer audioPlayer;

    public bool permitirSalto = false;
    public bool personajeGolpeado = false;


    private void Start()
    {
        velocidadOriginal = velocidad;
        audioPlayer = GetComponent<AudioPlayer>();
    }



    private void Update()
    {
        if(!personajeGolpeado)
        {
            MovimientoJugador();
            SaltoJugador();
            CorrerMasRapido();
        }

        if (vida <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }


    //MOVIMIENTO JUGADOR
    private void MovimientoJugador()
    {
        //Si es mayor que 0, voy a la derecha
        if(Input.GetAxis("Horizontal") >0)
        {
            if (GetComponent<AudioSource>().isPlaying == false && permitirSalto == true)
            {
                audioPlayer.ReproducirAudio(3);
            }
            playerSpriteRenderer.flipX = false;
            playerAnimator.SetBool("isRunning", true);
            //si es menor que 0, va a la izquierda
        } else if (Input.GetAxis("Horizontal") < 0)
        {
            if (GetComponent<AudioSource>().isPlaying == false && permitirSalto == true)
            {
                audioPlayer.ReproducirAudio(3);
            }
            playerSpriteRenderer.flipX = true;
            playerAnimator.SetBool("isRunning", true);
        } else if (Input.GetAxis("Horizontal") == 0)
        {
            playerAnimator.SetBool("isRunning", false);
        }

        playerRigidbody.velocity = new Vector2(velocidad * Input.GetAxis("Horizontal"), playerRigidbody.velocity.y);

    }




    //SALTO JUGADOR
    private void SaltoJugador()
    {
        
            if (Input.GetButtonDown("Jump") && permitirSalto == true)
            {
                playerRigidbody.AddForce(transform.up * impulso, ForceMode2D.Impulse);
                audioPlayer.ReproducirAudio(0);
                permitirSalto = false;
            }

        if (playerRigidbody.velocity.y > 0.5)
        {
            playerAnimator.SetBool("isJumping", true);
            playerAnimator.SetBool("isFalling", false);
        }
        else if (playerRigidbody.velocity.y < -0.5)
        {
            playerAnimator.SetBool("isJumping", false);
            playerAnimator.SetBool("isFalling", true);
        }
        else
        {
            playerAnimator.SetBool("isJumping", false);
            playerAnimator.SetBool("isFalling", false);
        }
            

    }

    private void CorrerMasRapido ()
    {
        if (Input.GetButton("Fire3"))
        {
            velocidad = velocidadAumentada;
        }

        if (Input.GetButtonUp("Fire3"))
        {
            velocidad = velocidadOriginal;
        }
    }

    public void ResetearMovimiento1()
    {
        Invoke("ResetearMovimiento2", 0.5f);
    }

    private void ResetearMovimiento2()
    {
        personajeGolpeado = false;
    }

    //COLLISIONES
    //OnCollisionEnter2D
    //OnCollisionExit2D
    //OnCollisionStay2D

    //OnTriggerEnter2D
    //OnTriggerExit2D
    //OnTriggerStay2D

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            permitirSalto = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            permitirSalto = false;
        }
    }

}
