using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackEventListner : MonoBehaviour
{
    [SerializeField] AttackManagerScript attackManager;
    [Header("Weapon")]
    [SerializeField] GameObject weaponObj;
    BoxCollider weaponCollider;

    private void Start() {
        weaponCollider = weaponObj.GetComponent<BoxCollider>();
        weaponCollider.enabled = false;
    }
    public void AttackStart()
    {
        weaponCollider.enabled = true;
        Debug.Log(weaponCollider.enabled);
    }
    public void AttackEnd()
    {
        weaponCollider.enabled = false;
        Debug.Log(weaponCollider.enabled);
    }
    // Start is called before the first frame update
    public void AnimEvent()
    {
        //Debug.Log("Animation phase complete");
        // attackManager.CheckAttackPhase();
    }
}
