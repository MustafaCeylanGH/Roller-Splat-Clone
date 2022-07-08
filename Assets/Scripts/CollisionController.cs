using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    private void OnTriggerEnter(Collider other)
    {       

        if (other.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(ActiveCanvas());
        }
        
    }

    IEnumerator ActiveCanvas()
    {
        yield return new WaitForSeconds(0.05f);
        canvas.SetActive(true);
    }
}
