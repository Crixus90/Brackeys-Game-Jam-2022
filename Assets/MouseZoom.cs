using UnityEngine;
using System.Collections;
using Cinemachine;

public class MouseZoom : MonoBehaviour
{

    public float zoomSensitivity = 15.0f;
    public float zoomSpeed = 5.0f;
    public float zoomMin = 45f;
    public float zoomMax = 60.0f;

    private float zoom;

    public CinemachineVirtualCamera vc;


    void Start()
    {
        zoom = vc.m_Lens.FieldOfView;
    }

    void Update()
    {
        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        zoom = Mathf.Clamp(zoom, zoomMin, zoomMax);
    }

    void LateUpdate()
    {
        vc.m_Lens.FieldOfView = Mathf.Lerp(vc.m_Lens.FieldOfView, zoom, Time.deltaTime * zoomSpeed);
    }
}