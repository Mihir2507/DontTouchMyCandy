using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackDamage : MonoBehaviour
{
    private BoxCollider swordCollider;

    private void Start(){
        swordCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider collider){
        IDamagable damagable = collider.GetComponent<IDamagable>();
        if(damagable != null){
            //hit a damagable object
            damagable.Damage();
            Debug.Log("Hit");
        }    
    }
}
