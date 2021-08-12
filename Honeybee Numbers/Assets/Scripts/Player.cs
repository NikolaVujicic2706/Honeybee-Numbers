using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    private int number;
    private float speed;
    public Rigidbody2D rb;


    public float Speed
    {
        get
        {
            return speed;
        }
        set { speed = value; }
    }
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        number = Random.Range(2, 10);
        speed = 10f;
        GetComponentInChildren<TextMeshProUGUI>().text = number.ToString();
    }

}
