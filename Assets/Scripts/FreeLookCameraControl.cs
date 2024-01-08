using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cinemachine;

public class FreeLookCameraControl : MonoBehaviour, IDragHandler // Add IPointerDownHandler and IPointerUpHandler to use OnPointerDown and OnPointerUp Functions 
{
    Image imgCamControlArea;
    [SerializeField] float SensitivityX = 0.005f;
    [SerializeField] float SensitivityY = -0.005f;
    [SerializeField] CinemachineFreeLook camFreeLook;
    string strMouseX = "Mouse X" , strMouseY = "Mouse Y";
    

    // Start is called before the first frame update
    void Start()
    {
        imgCamControlArea = GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
            imgCamControlArea.rectTransform,
            eventData.position,
            eventData.enterEventCamera,
            out Vector2 posout))
        {
            Debug.Log(posout);
            // camFreeLook.m_XAxis.m_InputAxisName = strMouseX;
            // camFreeLook.m_YAxis.m_InputAxisName = strMouseY;
            camFreeLook.m_XAxis.Value += posout.x * 200 * SensitivityX * Time.deltaTime;
            camFreeLook.m_YAxis.Value += posout.y * SensitivityY * Time.deltaTime;    
        }
    }

    // public void OnPointerDown(PointerEventData eventData)
    // {
    //     OnDrag(eventData);
    // }

    // public void OnPointerUp(PointerEventData eventData)
    // {
    //     camFreeLook.m_XAxis.m_InputAxisName = null;
    //     camFreeLook.m_YAxis.m_InputAxisName = null;
    //     // camFreeLook.m_XAxis.Value += 0;
    //     // camFreeLook.m_YAxis.Value += 0;  
    // }
}
