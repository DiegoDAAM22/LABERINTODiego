using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LABERINTO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //Jugador
            GameObject player = collision.gameObject;

            Rigidbody2D playerrigid =
                player.GetComponent<Rigidbody2D>();

            Vector2 fuerza = new Vector2(5, 5);
            playerrigid.AddForce(fuerza, ForceMode2D.Impulse);
            }
    }
}
