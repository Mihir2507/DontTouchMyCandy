using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CherriesCollision : MonoBehaviour
{
    public int cherries = 0;
    int rand;
    // [SerializeField] private GameObject prefab;

    [SerializeField] private TextMeshProUGUI cherryText;

    // [SerializeField] private TextMeshProUGUI cherryCountText;

    // private Vector3 cherryPosition;

    private void OnTriggerEnter(Collider other) {
        rand = Random.Range(100, 500);
        if(other.transform.tag == "cherries"){
            //cherryPosition = other.transform.position;
            cherries += rand;
            cherryText.text = cherries.ToString();
            //cherryCountText.text = rand.ToString();
            //Debug.Log(cherryCountText.text);
            Debug.Log(cherries);
            //scoreText.text = score.ToString();
            Destroy(other.gameObject);
            //Instantiate(prefab, cherryPosition, Quaternion.identity);
            //Invoke("DestroyCanvas", 1f);
        }
    }
    public void OnItemBuy(int newCherriesCount){
        cherries = newCherriesCount;
        cherryText.text = newCherriesCount.ToString();
    }

    // private void DestroyCanvas(){
    //     Destroy(prefab);
    // }
}
