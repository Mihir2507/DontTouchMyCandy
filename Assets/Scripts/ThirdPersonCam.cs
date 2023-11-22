using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonView : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform playerObj;

    [SerializeField] Transform combatLookAt;

    private void Start() {
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    private void Update() {
        Vector3 combatLookAtDir = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
        orientation.forward = combatLookAtDir.normalized;
        //Debug.Log(combatLookAtDir);
        playerObj.forward = combatLookAtDir.normalized;
    }

}
