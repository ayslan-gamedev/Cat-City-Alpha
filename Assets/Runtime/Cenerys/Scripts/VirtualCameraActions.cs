using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
[ExecuteInEditMode]
public class VirtualCameraActions : MonoBehaviour
{
    public void ChangeOrthographicSize(float orthoSize)
    {
        CinemachineVirtualCamera virtualCamera = GetComponent<CinemachineVirtualCamera>();
        virtualCamera.m_Lens.OrthographicSize = orthoSize;
    }
}