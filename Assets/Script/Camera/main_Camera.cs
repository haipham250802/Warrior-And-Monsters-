using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_Camera : MonoBehaviour
{

    public float LimitMaxX;
    public float LimitMinX;

    public float LimitMaxY;
    public float LimitMinY;

    public Transform Target;
    public float Damping;

    private Vector3 velocity = Vector3.zero;


    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }
    private void Update()
    {
        Follow();
    }
    void Follow()
    {
        if (Target)
        {
            Vector3 movePosition = Target.position;
            movePosition.x = Target.position.x;
            movePosition.y = Target.position.y + 0.5f;
            movePosition.z = -10;
            if (movePosition.y > LimitMaxY)
            {
                movePosition.y = LimitMaxY;
            }
            else if (movePosition.y < LimitMinY)
            {
                movePosition.y = LimitMinY;
            }
            if (movePosition.x > LimitMaxX)
            {
                movePosition.x = LimitMaxX;
            }
            else if (movePosition.x < LimitMinX)
            {
                movePosition.x = LimitMinX;
            }
            transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, Damping);
        }
    }
}
