using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public Player player;
   
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    private float swipeDuration;
    private float swipeStartTime;
    private float swipeEndTime;
    //private float moveDuration;
    private enum Direction {right, left};

    // Start is called before the first frame update
    void Start()
    {

        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
        swipeStartTime = 0f;
        swipeEndTime = 0f;
        //moveDuration = 0f;
        
    }

    private void Update()
    {
        if (Input.touchCount > 0) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                swipeStartTime = Time.time;
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                swipeEndTime = Time.time;
                lp = touch.position;  //last touch position.

                //Check if drag distance is greater than 15% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance)
                {//It's a drag

                    swipeDuration = swipeEndTime - swipeStartTime;
                    
                      //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            //transform.position = Vector3.Lerp(transform.position, transform.position + player.Speed * Vector3.right * Time.deltaTime, moveDuration/swipeDuration);
                            StartCoroutine(MovePlayer(Direction.right,swipeDuration));
                        }
                        else
                        {   //Left swipe
                            //transform.position = Vector3.Lerp(transform.position, transform.position + player.Speed * Vector3.left * Time.deltaTime, moveDuration/swipeDuration);
                            StartCoroutine(MovePlayer(Direction.left, swipeDuration));
                        }

                                         
                }
                
            }
        }
    }

    IEnumerator MovePlayer(Direction direction, float swipeDuration)
    {
        float moveDuration = 0f;

        while (moveDuration < swipeDuration)
        {
            moveDuration += Time.deltaTime;

            if (direction == Direction.right)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + player.Speed * Vector3.right * Time.deltaTime, moveDuration / swipeDuration);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, transform.position - player.Speed * Vector3.right * Time.deltaTime, moveDuration / swipeDuration);
            }
            yield return null;
        }


    }
}
    
