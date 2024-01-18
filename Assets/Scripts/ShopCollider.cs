using UnityEngine;

public class ShopCollider : MonoBehaviour
{
    [SerializeField] private UI_Shop shopUI;
    private void OnTriggerEnter(Collider collider){
        IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
        if(shopCustomer != null){
            shopUI.Show(shopCustomer);
            Debug.Log("Customer Came");
        }
    }
    private void OnTriggerExit(Collider collider){
        IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
        if(shopCustomer != null){
            shopUI.Hide();
            Debug.Log("Customer Left");
        }
    }  
}
