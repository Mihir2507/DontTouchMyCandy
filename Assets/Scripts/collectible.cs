using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class collectible : MonoBehaviour
{
    // [SerializeField] LayerMask whatIsGround;
    // [SerializeField] float coinHeight;
    [SerializeField] private TextMeshProUGUI scoreUI;
    private Rigidbody rb;
    private int score = 0;
    private bool onGround;
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            gameObject.SetActive(false);
            Debug.Log("Collided");
            score++;
            scoreUI.text = score.ToString();
        }
        Invoke("ActiveCollectible",1);
    }
    // private void OnCollisionEnter(Collision other) {
    //     if(other.collider.CompareTag("whatIsGround"))
    //     {
    //         rb.useGravity = false;
    //     }
    //     if(other.gameObject.name == "Player"){
    //         gameObject.SetActive(false);
    //         Debug.Log("Collided");
    //         score++;
    //         Debug.Log("Score" + score);
    //     }
    //     Invoke("ActiveCollectible",2);
    // }
    // private void Start()
    // {
    //     rb = GetComponent<Rigidbody>();
    // }

    private void ActiveCollectible()
    {
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(100f,130f), 31, UnityEngine.Random.Range(60f, 90f));
        transform.position = spawnPosition;
        gameObject.SetActive(true);

    }
    // private void Update()
    // {
    //     onGround = Physics.Raycast(transform.position, Vector3.down, coinHeight + 1f, whatIsGround);
    //     if(onGround)
    //     {
    //         Debug.Log("Working");
    //         rb.useGravity = false;
    //     }
    // }
    // private void Start()
    // {
    //     objectPooler = ObjectPooler.Instance;
    // }
    // private void Update()
    // {
    //     Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(0f,50f), 2, UnityEngine.Random.Range(0f, 50f));
    //     objectPooler.SpawnFromPool("coin", spawnPosition, Quaternion.identity);
    // }

}
