using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapIconFollower : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, 200f, playerTransform.position.z);
    }
}
