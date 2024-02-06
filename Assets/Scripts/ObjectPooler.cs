using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool{
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public Vector2 negativePosition, positivePosition;
    float distanceBetweenSpawn = 300;
    public List<Pool> pools;
    [SerializeField] Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start(){
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach ( Pool pool in pools)
        {
            Queue<GameObject> objectPooled = new Queue<GameObject>();
            for(int i = 0; i<pool.size; i++){
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPooled.Enqueue(obj);
            }
            
            poolDictionary.Add(pool.tag, objectPooled);
        }
        
        SpawnFromPool("enemy", new Vector3(1,2,1));
        // SpawnFromPool("enemy", new Vector3(430,2,390), quaternion.identity);
    }

    public GameObject SpawnFromPool(string tag, Vector3 position){
        if(!poolDictionary.ContainsKey(tag)){
            Debug.Log("pool with tag "+ tag + " dosen't exist");
            return null;
        }
        Debug.Log(poolDictionary[tag].Count + " count before dequeue");
        GameObject objectToSpawn =  poolDictionary[tag].Dequeue();
        float xpositive = 242f , xnegative = 1088f;
        float zpositive = 5 , znegative = 10;
        int size = poolDictionary[tag].Count;
        for(float x = negativePosition.x; x> positivePosition.x; x-= distanceBetweenSpawn){
            for(float z = negativePosition.y; z<positivePosition.y; z+=distanceBetweenSpawn){
                Debug.Log(x +", "+z);
                objectToSpawn =  poolDictionary[tag].Dequeue();
                //Debug.Log(poolDictionary[tag].Count + " spaened");    
                objectToSpawn.SetActive(true);
                objectToSpawn.transform.position = new Vector3(x, 0, z);
            }
        }
        for(int i=0; i< size; i++){
            float randomx = Random.Range(xpositive, xnegative);
            float randomz = Random.Range(zpositive, znegative);
            // objectToSpawn =  poolDictionary[tag].Dequeue();
            // Debug.Log(poolDictionary[tag].Count + " spaened");    
            // objectToSpawn.SetActive(true);
            // objectToSpawn.transform.position = new Vector3(randomx+20, 0, randomz);
            //objectToSpawn.transform.rotation = quaternion.identity;
        }
        Debug.Log(poolDictionary[tag].Count + " count after dequeue");
        poolDictionary[tag].Enqueue(objectToSpawn);
        Debug.Log(poolDictionary[tag].Count + " count after enqueue");
        return objectToSpawn;
    }
}
