using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   
    float horizontalPosition;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
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
        //transform.position = transform.position + Vector3.right * speed * Time.deltaTime * horizontalPosition;
    }
}
