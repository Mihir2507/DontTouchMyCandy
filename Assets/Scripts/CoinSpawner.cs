using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    private Vector3 spawnPosition;
    int i=0;
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }
    private void FixedUpdate()
    {
        if(i<31){
            spawnPosition = new Vector3(UnityEngine.Random.Range(100f,130f), 31, UnityEngine.Random.Range(10f, 70f));
            ObjectPooler.Instance.SpawnFromPool("coin", spawnPosition, Quaternion.identity);
            Debug.Log("Coin"+i);
            i++;
        }
    }
}
