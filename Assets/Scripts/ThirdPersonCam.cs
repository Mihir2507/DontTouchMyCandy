using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ThirdPersonView : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerObj;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick fj;

    [SerializeField] float rotationSpeed;

    [SerializeField] Transform combatLookAt;
    [SerializeField] CameraStyle currentStyle;
    public enum CameraStyle
    {
        Basic,
        Combat,
        Topdown
    }

    [SerializeField] GameObject thirdPersoncam;
    [SerializeField] GameObject combatLookAtCam;
    [SerializeField] GameObject topdownCam;
    private int count =1; 
    private void Start() {
        //Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

    public void ChangeCamera()
    {
        if(count == 1 && Input.touchCount >0)
        {
            SwitchCameraStyle(CameraStyle.Basic);
            count++;
        }
        else if(count == 2 && Input.touchCount>0 )
        {
            SwitchCameraStyle(CameraStyle.Combat);
            count++;
        }
        else
        {
            SwitchCameraStyle(CameraStyle.Topdown);
            count = 1;
        }
    }

    private void Update() {

        //Switch camera
        // if(Input.GetKey(KeyCode.Alpha1)) SwitchCameraStyle(CameraStyle.Basic);
        // if(Input.GetKey(KeyCode.Alpha2)) SwitchCameraStyle(CameraStyle.Combat);
        // if(Input.GetKey(KeyCode.Alpha3)) SwitchCameraStyle(CameraStyle.Topdown);

        //rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        
       

        //rotate playerObj
        if(currentStyle == CameraStyle.Basic || currentStyle == CameraStyle.Topdown)
        {
            float horizontalInput = fj.Horizontal;
            float verticalInput = fj.Vertical;
            orientation.forward = viewDir.normalized;
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            // if(inputDir != Vector3.zero)
            // {
            //     playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            // }
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }

        else if(currentStyle == CameraStyle.Combat)
        {
            Vector3 combatLookAtDir = combatLookAt.position - new Vector3(transform.position.x, combatLookAt.position.y, transform.position.z);
            orientation.forward = combatLookAtDir.normalized;
            //Debug.Log(combatLookAtDir);
            playerObj.forward = combatLookAtDir.normalized;
        }
    }

    private void SwitchCameraStyle(CameraStyle newStyle)
    {
        thirdPersoncam.SetActive(false);
        combatLookAtCam.SetActive(false);
        topdownCam.SetActive(false);

        if(newStyle == CameraStyle.Basic) thirdPersoncam.SetActive(true);
        if(newStyle == CameraStyle.Combat) combatLookAtCam.SetActive(true);
        if(newStyle == CameraStyle.Topdown) topdownCam.SetActive(true);

        currentStyle = newStyle;
    }

}
