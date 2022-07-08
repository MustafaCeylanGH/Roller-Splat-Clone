using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private GameObject Ground;
    private Vector3 firstPos;
    private Vector3 secondPos;
    private Vector3 currentPos;
    private int mainBoundary = 0;
    private float sensitiveBoundary = 0.5f;
    [SerializeField] private float moveSpeed = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }

    private void Update()
    {
        Swipe();
    }
    private void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y,transform.position.z);
        }
       
        if (Input.GetMouseButtonUp(0))
        {
            secondPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);

            currentPos = new Vector3(secondPos.x - firstPos.x, secondPos.y-firstPos.y,transform.position.z);
        }

        currentPos.Normalize();

        if (currentPos.x<mainBoundary && currentPos.y>-sensitiveBoundary && currentPos.y< sensitiveBoundary)
        {
            rb.velocity = Vector3.back * moveSpeed;
        }
        else if (currentPos.x > mainBoundary && currentPos.y > -sensitiveBoundary && currentPos.y < sensitiveBoundary)
        {
            rb.velocity = Vector3.forward * moveSpeed;
        }
        else if (currentPos.y > mainBoundary && currentPos.x > -sensitiveBoundary && currentPos.x < sensitiveBoundary)
        {
            rb.velocity = Vector3.left * moveSpeed;
        }
        else if (currentPos.y < mainBoundary && currentPos.x > -sensitiveBoundary && currentPos.x < sensitiveBoundary)
        {
            rb.velocity = Vector3.right * moveSpeed;
        }

    }
}


