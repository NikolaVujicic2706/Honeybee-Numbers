using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    private float movement;
    public Rigidbody2D rb;
    private int number;
    //public Transform movePlayer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        number = Random.Range(2, 10);
        GetComponentInChildren<TextMeshProUGUI>().text = number.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement != 0)
        {

            transform.position = new Vector2(movement * 5, transform.position.y);
        }

    }         
        
 }
