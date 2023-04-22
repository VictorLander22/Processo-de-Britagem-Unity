using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus;

// ainda tenho q testar peguei do GPT
public class CameraController : MonoBehaviour
{
    public float sensitivity = 0.1f;
    public OVRCameraRig cameraRig;

    void Update()
    {
        float xRotation = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y;
        float yRotation = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).x;

        Vector3 rotation = new Vector3(-xRotation, yRotation, 0f) * sensitivity;
        cameraRig.transform.localRotation *= Quaternion.Euler(rotation);
    }
}
