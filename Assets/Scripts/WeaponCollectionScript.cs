using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollectionScript : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject playerBasicSword;
    // private void OnCollisionEnter(Collision other) {
    //     anim.SetBool("IsCollected", true);
    // }
    private void OnTriggerEnter(Collider other) {
        anim.SetBool("IsCollected", true);
       
        Invoke("DestroyObject", 2);

    }
    private void DestroyObject()
    {
        Destroy(gameObject);
        playerBasicSword.SetActive(true);
    }
    // private void SetPlayerSwordActive()
    // {
    //     playerBasicSword.SetActive(true);
    // } 
}
