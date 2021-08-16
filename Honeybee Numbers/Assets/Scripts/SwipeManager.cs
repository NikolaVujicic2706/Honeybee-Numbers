using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    private float horizontalPosition;
    public Player player;
   

    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    private enum Direction {right, left};

    // Start is called before the first frame update
    void Start()
    {

        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
        
    }

    private void Update()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list

                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    Vector2 touch_Pos = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y));

                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            Debug.Log("Right Swipe");
                            //transform.position += Vector3.right * Time.deltaTime * player.Speed;
                            //transform.position = Vector3.Lerp(transform.position, transform.position + player.Speed * Vector3.right * Time.deltaTime, 0.5f);
                            StartCoroutine(MovePlayer(Direction.right));
                        }
                        else
                        {   //Left swipe
                            Debug.Log("Left Swipe");
                            //transform.position += Vector3.left * Time.deltaTime * player.Speed;
                            //transform.position = Vector3.Lerp(transform.position, transform.position + player.Speed * Vector3.left * Time.deltaTime, 0.5f);
                            StartCoroutine(MovePlayer(Direction.left));
                        }


                    }
                }
                
            }
        }
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        
        if (direction != 0)
        {

            Vector2 newPosition = player.rb.position + Vector2.right * direction * player.Speed * Time.fixedDeltaTime;
            player.rb.MovePosition(newPosition);

        }
    }*/

    IEnumerator MovePlayer(Direction direction)
    {
        if (direction == Direction.right)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + player.Speed * Vector3.right * Time.deltaTime, 0.5f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + player.Speed * Vector3.left * Time.deltaTime, 0.5f);
        }
        yield return null;
    }
}
    
