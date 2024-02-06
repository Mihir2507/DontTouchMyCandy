using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionWithAnySurface : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    private Vector3 newposu;
    // float lerpSpeed = 0.5f;
     private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves a specific tag
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with player detected!");
            playerRb.transform.position = playerRb.transform.position + new Vector3(0.1f,0.1f,0.1f);
            // playerRb.AddForce(-Vector3.forward * 100, ForceMode.Force);
            // playerRb.AddForce(Vector3.up * 4f, ForceMode.Force);
            // float t = Mathf.PingPong(Time.time * lerpSpeed, 1f);
            // playerRb.transform.position = Vector3.Lerp(playerRb.transform.position, newposu, t);
            // Add your logic here
        }
    }
}
