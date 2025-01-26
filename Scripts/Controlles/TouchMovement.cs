using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{
    public Transform Player;
    private float xRotation = 0f;
    private Vector2 touchStartPos;
    private Vector2 touchDelta;
    
    float mouseX;
    float mouseY;


    void Start()
    {
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                touchDelta = touch.position - touchStartPos;

                touchStartPos = touch.position;

                mouseX = touchDelta.x * 0.1f; 
                mouseY = touchDelta.y * 0.1f;

                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);
                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

                Player.transform.Rotate(Vector3.up * mouseX);
            }
        }
    }
}
