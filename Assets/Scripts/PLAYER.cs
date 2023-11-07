using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    Rigidbody2D fisicaplayer;
    SpriteRenderer colorplayer;
    public float speed;
    Vector2 vectormovimiento;
    public float movex;
    public float movey;
    public GameObject WIN;
    public GameObject MEH;
    public GameObject LOSS;
    public AudioSource Musica;
    public AudioSource FX;
    public AudioSource vic;
    public TMP_Text textoContador;
    public int monedas = 0;
    private bool bloqueo = false;

    public float tiempo = 0;


    // Start is called before the first frame update
    void Start()
    {
        fisicaplayer = GetComponent<Rigidbody2D>();
        colorplayer = GetComponent<SpriteRenderer>();
        WIN = GameObject.Find("WIN");
        MEH = GameObject.Find("MEH");
        LOSS = GameObject.Find("LOSS");
        FX = GameObject.Find("FX").GetComponent<AudioSource>();
        vic = GameObject.Find("vic").GetComponent<AudioSource>();
        Musica = GameObject.Find("Musica").GetComponent<AudioSource>();
        Musica.Play();
        WIN.SetActive(false);
        MEH.SetActive(false);
        LOSS.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (bloqueo)
        {
            tiempo += Time.deltaTime;
            vectormovimiento = new Vector2(0, 0);
            fisicaplayer.velocity = vectormovimiento * speed;
            
            if (tiempo >= 2) 
            { bloqueo = (false);
                colorplayer.color = Color.white;
            }
 
        }
        else
        {
            movex = Input.GetAxis("Horizontal");
            movey = Input.GetAxis("Vertical");
            vectormovimiento = new Vector2(movex, movey);
            fisicaplayer.velocity = vectormovimiento * speed;
            tiempo += Time.deltaTime;
        }



    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "monedas")
        {
            Destroy(collision.gameObject);
            FX.Play();
            monedas++;
            textoContador.text = monedas.ToString();
        }
        else if (collision.gameObject.tag == "final")
        {
            vic.Play();
            Musica.Stop();

            if (monedas >= 6)
            { WIN.SetActive(true); }
            else if (monedas >= 3)
            { MEH.SetActive(true); }
            else
            { LOSS.SetActive(true); } 
        }
        if (collision.gameObject.tag == "laberinto")
        {
            bloqueo = true;
            tiempo = 0;
            colorplayer.color = Color.red;


        }

    }

    
}