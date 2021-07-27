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

    private void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBoundary, screenBoundary), transform.position.y);

    }
    void FixedUpdate()
    {
        horizontalPosition = Input.GetAxis("Horizontal");
        if (horizontalPosition != 0)
        {

            Vector2 movement = new Vector2(horizontalPosition, 0);
            rb.MovePosition( rb.position + movement * speed * Time.deltaTime);
                        
        }

    }         
        
 }
