using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    [SerializeField] private Animator anim;
    //[SerializeField] private Rigidbody player;
    [SerializeField] private FixedJoystick fj;
    // NEwMovements newMovements = new NEwMovements();
    [SerializeField] NEwMovements newMovements;
    [SerializeField] Transform gfxTransform;
    // void Start()
    // {
    //     anim = GetComponent<Animator>();
    //     // newMovements = GetComponent<NEwMovements>();
    // }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Freeze Movement of the graphics of the player i.e. playerObj
        //transform.localPosition = new Vector3(0, 0, 0);
        gfxTransform.localPosition = new Vector3(0, 0, 0);
        //Vector3 currentPosition = new Vector3(player.velocity.x, player.velocity.y, player.velocity.z);
        float inputH = fj.Horizontal;
        float inputV = fj.Vertical;
        if(inputH > 0.01f || inputV > 0.01f || inputH < -0.01f || inputV < -0.01f){
            anim.SetBool("IsIdle", false);
            //anim.SetBool("IsAttacking", false);
            if(newMovements.isAttacking == true)
            {
                anim.SetBool("IsAttacking", true);
            }
            else{
                anim.SetBool("IsAttacking", false);
            }
            if(newMovements.enemyInSightRange == true)
            {
                anim.SetBool("EnemyInSightRange",true);
            }
            else{
                anim.SetBool("EnemyInSightRange", false);
                anim.SetBool("IsRunning", true);
            }
            if(newMovements.isJumping == true){
                anim.SetBool("IsJumpingRunning", true);
            }
            else{
                // anim.SetBool("IsJumpingRunning", false);
                if(newMovements.grounded == false)
                {
                    //anim.SetBool("IsJumpingRunning", false);
                    anim.SetBool("IsFloating", true);
                }
                else
                    anim.SetBool("IsJumpingRunning", false);
                    anim.SetBool("IsFloating", false);
            }
        }
        else{
            anim.SetBool("IsIdle", true);
            if(newMovements.isAttacking == true)
            {
                anim.SetBool("IsAttacking", true);
                anim.SetBool("EnemyInSightRange", false);
                anim.SetBool("IsRunning", false);
            }
            else{
                anim.SetBool("IsAttacking", false);
            }
            anim.SetBool("EnemyInSightRange", false);
            anim.SetBool("IsRunning", false);
            if(newMovements.isJumping == true){
                Debug.Log("Jumping");
                anim.SetBool("IsJumpingIdle", true);
            }
            else{
                anim.SetBool("IsJumpingIdle", false);
            }
        }
    }
}
