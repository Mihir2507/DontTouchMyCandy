using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private void LateUpdate() {
        Vector3 newPosition = playerTransform.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        // transform.rotation = Quaternion.Euler(90f, playerTransform.eulerAngles.y, 0f);
    }

}
