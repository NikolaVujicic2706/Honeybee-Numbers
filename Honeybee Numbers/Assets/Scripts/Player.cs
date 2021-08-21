using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    private float timeBetweenColorChange = 3f;
    private int colorChanges;
    private int number;
    private float speed;
    private TrailRenderer tr;
    private SpriteRenderer sr;
    private Color randomColor;
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
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<TrailRenderer>();
        ChangePlayerColor();
        rb = GetComponent<Rigidbody2D>();
        number = Random.Range(2, 10);
        speed = 30f;
        GetComponentInChildren<TextMeshProUGUI>().text = number.ToString();
        

        
    }
    
        private void Update()
    {
       
        if (Time.time > timeBetweenColorChange * colorChanges)
        {
            ChangePlayerColor();
            
        }
    }

    private void ChangePlayerColor()
    {
        randomColor = new Color(
                                    Random.Range(0f, 1f), //Red
                                    Random.Range(0f, 1f), //Green
                                    Random.Range(0f, 1f),//Blue
                                    1 //Alpha (transparency)
                                    );
        this.sr.material.SetColor("_Color", randomColor);
        this.tr.material.SetColor("_Color", randomColor);

        colorChanges++;
    }
}
