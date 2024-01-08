using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDamageScript : MonoBehaviour
{
    private BoxCollider boxCol;
    // Start is called before the first frame update
    void Start()
    {
        boxCol = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider collider) {
        IDamagable damagable = collider.GetComponent<IDamagable>();
        if(damagable != null && collider.tag == "Player"){
            damagable.Damage();
            Debug.Log("Hit Player");
        }
    }
}
