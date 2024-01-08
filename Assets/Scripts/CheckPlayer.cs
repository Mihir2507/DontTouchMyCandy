using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    [SerializeField] Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("IsFruitCollected", true);
        Invoke("DestroyObject", 2);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
