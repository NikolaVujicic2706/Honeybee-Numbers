using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    
   
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
    private float swipeDuration;
    private float swipeStartTime;
    private float swipeEndTime;
    private float swipeDistance;
    private enum Direction {right, left};
    public Player player;

    // Start is called before the first frame update
    void Start()
    {

        dragDistance = Screen.height * 3 / 100; //dragDistance is 3% height of the screen
            
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
                swipeDistance = Mathf.Abs(lp.x - fp.x);

                //Check if drag distance is greater than 3% of the screen height
                if (swipeDistance > dragDistance)
                {//It's a drag

                    swipeDuration = swipeEndTime - swipeStartTime;
                   
                    
                      //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            //transform.position = Vector3.Lerp(transform.position, transform.position + player.Speed * Vector3.right * Time.deltaTime, moveDuration/swipeDuration);
                            StartCoroutine(MovePlayer(Direction.right,swipeDuration,swipeDistance));
                                                }
                        else
                        {   //Left swipe
                            //transform.position = Vector3.Lerp(transform.position, transform.position + player.Speed * Vector3.left * Time.deltaTime, moveDuration/swipeDuration);
                            StartCoroutine(MovePlayer(Direction.left, swipeDuration,swipeDistance));
                        }

                                         
                }
                
            }
        }
    }

    IEnumerator MovePlayer(Direction direction, float swipeDuration, float swipeDistance)
    {
        float moveDuration = 0f;

        while (moveDuration < swipeDuration)
        {
            moveDuration += Time.deltaTime;

            if (direction == Direction.right)
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + player.Speed * Vector3.right * Time.deltaTime * swipeDistance/250, moveDuration / swipeDuration);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, transform.position - player.Speed * Vector3.right * Time.deltaTime * swipeDistance/250, moveDuration / swipeDuration);
            }
            yield return null;
        }
        

    }
}
    
