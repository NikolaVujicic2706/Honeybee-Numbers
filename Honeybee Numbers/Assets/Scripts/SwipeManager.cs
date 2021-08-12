using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    private float horizontalPosition;
    public Player player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
   
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalPosition = Input.GetAxis("Horizontal");
        if (horizontalPosition != 0)
        {

            Vector2 newPosition = player.rb.position + Vector2.right * horizontalPosition * player.Speed * Time.fixedDeltaTime;
            player.rb.MovePosition(newPosition);

        }
    }
}
