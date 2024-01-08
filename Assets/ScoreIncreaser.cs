using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreIncreaser : MonoBehaviour
{
    int score = 0;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            score++;
            //scoreText.text = score.ToString();
            Invoke("DestroyObject", 0.5f);
        }
    }

    private void DestroyObject(){
        Destroy(gameObject);
        Debug.Log(score);
    }
}
