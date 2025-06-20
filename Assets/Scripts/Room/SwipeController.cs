using DG.Tweening;
using System.Collections;
using UnityEngine;


public class SwipeController : MonoBehaviour
{
    private Vector2 touchStart, touchEnd;
    public float swipeThreshold = 100f;
    public float rotationDuration = 2.0f;

    public GameObject cameraPivot;

    void Update()
    {
        if(PlayerController.Instance.state == PlayerController.State.Focused) 
        {
            touchEnd = Vector2.zero;
            touchStart = Vector2.zero;
        }

        if (PlayerController.Instance.state == PlayerController.State.Global) 
        {
            if (Input.touches.Length > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    touchStart = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    touchEnd = touch.position;
                    float swipeDistance = Vector2.Distance(touchStart, touchEnd);

                    if (swipeDistance > swipeThreshold)
                    {
                        Vector2 swipeDirection = touchEnd - touchStart;

                        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
                        {
                            if (swipeDirection.x > 0)
                            {
                                OnSwipeRight();
                            }
                            else
                            {
                                OnSwipeLeft();
                            }
                        }
                        else
                        {
                            if (swipeDirection.y > 0)
                            {
                                OnSwipeUp();
                            }
                            else
                            {
                                OnSwipeDown();
                            }
                        }
                    }
                }
            }

            if (cameraPivot.transform.rotation.eulerAngles.y >= 360f)
            {
                cameraPivot.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }  
    }

    private void OnSwipeRight()
    {
        Debug.Log("Swiped Right");
        cameraPivot.transform.DORotate(new(0, cameraPivot.transform.rotation.eulerAngles.y + 90, 0), 1f);
    }

    private void OnSwipeLeft()
    {
        Debug.Log("Swiped Left");
        cameraPivot.transform.DORotate(new(0, cameraPivot.transform.rotation.eulerAngles.y - 90, 0), 1f);
    }

    private void OnSwipeUp()
    {
        Debug.Log("Swiped Up");
    }

    private void OnSwipeDown()
    {
        Debug.Log("Swiped Down");
    }

}
