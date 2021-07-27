using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    private float horizontalPosition;
    public Rigidbody2D rb;
    private int number;
    public float speed = 10f;
    private float screenBoundary = 14.6f;
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
        horizontalPosition = Input.GetAxis("Horizontal");
        if (horizontalPosition != 0)
        {

            Vector2 newPosition = rb.position + Vector2.right * horizontalPosition * speed * Time.fixedDeltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, -screenBoundary, screenBoundary);
            rb.MovePosition( newPosition);
                        
        }

    }         
        
 }
