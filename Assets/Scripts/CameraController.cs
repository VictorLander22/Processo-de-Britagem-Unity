using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic; // para criar as listas

// Ainda tenho que testar. Codigo para o movimento usando os controles do oculus quest. Esta anexado ao objeto Camera offset dentro do XR Origin

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float rotationSpeed = 1.0f;

    private InputDevice leftController;
    private InputDevice rightController;

    private Vector2 leftThumbstick;
    private Vector2 rightThumbstick;

    void Start()
    {
        // Procura os controladores Oculus Touch na cena
        List<InputDevice> leftDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(
            InputDeviceCharacteristics.Controller
                | InputDeviceCharacteristics.Left
                | InputDeviceCharacteristics.TrackedDevice,
            leftDevices
        );
        if (leftDevices.Count > 0)
        {
            leftController = leftDevices[0];
        }

        List<InputDevice> rightDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(
            InputDeviceCharacteristics.Controller
                | InputDeviceCharacteristics.Right
                | InputDeviceCharacteristics.TrackedDevice,
            rightDevices
        );
        if (rightDevices.Count > 0)
        {
            rightController = rightDevices[0];
        }
    }

    void Update()
    {
        // Verifica se os controladores estão conectados
        if (leftController.isValid && rightController.isValid)
        {
            // Translacao -polegar esquerdo
            leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out leftThumbstick);
            transform.position += transform.forward * leftThumbstick.y * moveSpeed * Time.deltaTime;
            transform.position += transform.right * leftThumbstick.x * moveSpeed * Time.deltaTime;

            // Rotacao - polegar direito
            rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out rightThumbstick);
            transform.Rotate(Vector3.up, rightThumbstick.x * rotationSpeed * Time.deltaTime);
        }
    }
}
