using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] Enemy enemyScript;
    [SerializeField] Transform rotate;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update() {
        transform.rotation = rotate.rotation;
    }
    private void FixedUpdate()
    {
        // Freeze Movement of the graphics of the player i.e. playerObj
        transform.localPosition = new Vector3(0, 0, 0);
        
        // transform.rotation = rotationF;
        // transform.localRotation = new Vector3(0, 0, 0);
        if(enemyScript.isChasing)
        {
            anim.SetBool("IsChasing", true);
        }
        
        // if(enemyScript.isStandingForAttack)
        // {
        //     anim.SetBool("IsStandingForAttack", true);
        // }
        // else{
        //     anim.SetBool("IsStandingForAttack", false);
        // }

        if(enemyScript.isAttacking)
        {
            anim.SetBool("IsAttacking", true);
        }
        else{
            anim.SetBool("IsAttacking", false);
        }
    }
}
