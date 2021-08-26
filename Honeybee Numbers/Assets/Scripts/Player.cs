using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{
    private float timeBetweenColorChange = 6f;
    private int colorChanges;
    private int numberOne;
    private int numberTwo;
    private float speed;
    private TrailRenderer tr;
    private SpriteRenderer sr;
    private Color randomColor;
    public Rigidbody2D rb;
    public TextMeshProUGUI textMP;


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
        textMP = GetComponentInChildren<TextMeshProUGUI>();
        ChangePlayer();
        rb = GetComponent<Rigidbody2D>();
        numberOne = Random.Range(2, 9);
        numberTwo = Random.Range(2, 9);
        speed = 30f;
        textMP.text = numberOne.ToString() + "x" + numberTwo.ToString();
        

        
    }
    
        private void Update()
    {
       
        if (Time.time > timeBetweenColorChange * colorChanges)
        {
            ChangePlayer();
            
        }
    }

    private void ChangePlayer()
    {
        randomColor = new Color(
                                    Random.Range(0f, 1f), //Red
                                    Random.Range(0f, 1f), //Green
                                    Random.Range(0f, 1f),//Blue
                                    1 //Alpha (transparency)
                                    );
        this.sr.material.SetColor("_Color", randomColor);
        this.tr.material.SetColor("_Color", randomColor);
        numberOne = Random.Range(2, 9);
        numberTwo = Random.Range(2, 9);
        textMP.text = numberOne.ToString() + "x" + numberTwo.ToString();
        colorChanges++;
    }
}
