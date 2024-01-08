using UnityEngine;
using Cinemachine;

public class Cinetouch : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook cineCam;
    [SerializeField] TouchField touchField;
    [SerializeField] float SenstivityX = 2f;
    [SerializeField] float SenstivityY = 2f;

    // Update is called once per frame
    void Update()
    {
        // cineCam.m_XAxis.m_InputAxisName = "Mouse X";
        // cineCam.m_YAxis.m_InputAxisName = "Mouse y";
        cineCam.m_XAxis.Value += touchField.TouchDist.x * 200 * SenstivityX * Time.deltaTime;
        cineCam.m_YAxis.Value += touchField.TouchDist.y * SenstivityY * Time.deltaTime;
    }
}