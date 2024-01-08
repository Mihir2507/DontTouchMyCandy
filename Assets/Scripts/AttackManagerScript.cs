using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManagerScript : MonoBehaviour
{
    //Component
    [SerializeField] Animator playerObjAnim;
    
    //others
    public int countAttackClick;
    // Start is called before the first frame update
    void Start()
    {
        countAttackClick = 0;
    }

// UI ButtonAttack
    public void BtnClick()
    {
        countAttackClick++;
        //Debug.Log("Click count :" + countAttackClick);
        playerObjAnim.SetInteger("IntAttackPhase", 1);
        if(countAttackClick == 1)
        {
            Debug.Log(countAttackClick);
        }
        // else if(countAttackClick == 2){
        //     playerObjAnim.SetInteger("IntAttackPhase", 1);
        // }
        // else if(countAttackClick >= 3){
        //     // ResetAttackPhase();
        // }
    }

    // public void CheckAttackPhase()
    // {
    //     Debug.Log("Checking attack phase:");
    //     if(playerObjAnim.GetCurrentAnimatorStateInfo(1).IsName("Sword And Shield Slash")){
    //         Debug.Log("Current state : 1");
    //         if(countAttackClick > 1){
    //             // Next attack phase
    //             playerObjAnim.SetInteger("IntAttackPhase", 2);
    //         }
    //         else{
    //             ResetAttackPhase();
    //         }
    //     }
    //     else if(playerObjAnim.GetCurrentAnimatorStateInfo(1).IsName("Sword And Shield Slash2")){
    //         Debug.Log("Current State : 2");
    //         if(countAttackClick > 2){
    //             // Next attack phase
    //             playerObjAnim.SetInteger("IntAttackPhase", 3);
    //         }
    //         else{
    //             ResetAttackPhase();
    //         }
    //     }
    //     else if(playerObjAnim.GetCurrentAnimatorStateInfo(1).IsName("Sword SlashCombo")){
    //         Debug.Log("Current State : 3");
    //         if(countAttackClick >= 3){
    //             ResetAttackPhase();
    //         }
    //     }
    // }

    // private void ResetAttackPhase()
    // {
    //     countAttackClick = 0;
    //     playerObjAnim.SetInteger("IntAttackPhase", 0);
    // }
}
