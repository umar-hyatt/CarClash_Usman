using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 1000f;
    // private float speed = 0.005f;
    // private Touch touch;
    private Vector2 startTouchPosition, endTouchPosition;
    private Vector3 startRocketPosition, endRocketPosition;
    private float flyTime;
    private float flightDuration = 0.1f;


    // Update is called once per frame
    void FixedUpdate()
    {
        // transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + forwardForce);
        // rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        // if (Input.touchCount > 0)
        // {
        //     touch = Input.GetTouch(0);
        //     if (touch.phase == TouchPhase.Moved)
        //     {
        //         Debug.Log("movement working");
        //         transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed, transform.position.y, transform.position.z);
        //     }
        // }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if ((endTouchPosition.x < startTouchPosition.x) && transform.position.x > -1.75f)
            StartCoroutine(Fly("left"));

            if ((endTouchPosition.x < startTouchPosition.x) && transform.position.x < 1.75f)
            StartCoroutine(Fly("right"));
        }

    }
    private IEnumerator Fly(string whereToFly)
    {
        switch (whereToFly)
        {
            case "left":
                flyTime = 0f;
                startRocketPosition = transform.position;
                endRocketPosition = new Vector3(startRocketPosition.x - 1.75f, transform.position.y, transform.position.z);

                while (flyTime < flightDuration)
                {
                    flyTime += Time.deltaTime;
                    transform.position = Vector2.Lerp(startRocketPosition, endRocketPosition, flyTime / flightDuration);
                    yield return null;
                }
                break;

            case "right":
                flyTime = 0f;
                startRocketPosition = transform.position;
                endRocketPosition = new Vector3(startRocketPosition.x + 1.75f, transform.position.y, transform.position.z);

                while (flyTime < flightDuration)
                {
                    flyTime += Time.deltaTime;
                    transform.position = Vector2.Lerp(startRocketPosition, endRocketPosition, flyTime / flightDuration);
                    yield return null;
                }
                break;
        }
    }

}

