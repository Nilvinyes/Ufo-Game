using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;

    GameObject[] pickup; 
    int totalpickup;

    [SerializeField]
    TextMeshProUGUI puntuacio;

    private Rigidbody2D rb2d;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        pickup = GameObject.FindGameObjectsWithTag("Pickup"); // posem a pickup el els GameObjects
        totalpickup = pickup.Length;
        puntuacio.text = Convert.ToString("Et falten: " + totalpickup); // posem per pantalla el total de pickups

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHoritzontal = Input.GetAxis("Horizontal");
        float moveVeritcal = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHoritzontal, moveVeritcal);
        rb2d.AddForce(movement * speed);

        if (Input.GetKey(KeyCode.Escape)) // si cliquem Escape sortim del joc
        {
            Application.Quit();
            Debug.Log("Programa tancat");
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag.Equals("Pickup")) // si colisionem eliminem el pickup, i mostrem per pantalla el total que falta
        {
            totalpickup--;
            Destroy(collision.gameObject);
            puntuacio.text = Convert.ToString("Et falten: " + totalpickup);
        }

        if (totalpickup == 0) // si és 0 significa que jo no en queden, mostrem per pantalla que hem guanyat
        {
            puntuacio.color = Color.green;
            puntuacio.fontSize = 60;
            puntuacio.text = ("Enhorabona has guanyat.  Fet per en Nil Vinyes");
        }
     
       
    }
}
