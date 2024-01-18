using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreIncreaser : MonoBehaviour
{
    int score = 0;

    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player"){
            score++;
            Debug.Log(score);
            //scoreText.text = score.ToString();
            Destroy(gameObject);
        }
    }

    // private void DestroyObject(){
    //     Destroy(gameObject);
    //     Debug.Log(score);
    // }
}
