using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic; // para criar as listas

// Ainda tenho que testar. Codigo para o movimento usando os controles do oculus quest. Esta anexado ao objeto Camera offset dentro do XR Origin

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f; // Velocidade de movimento do objeto

    private void Update()
    {
        // Obter os valores dos joysticks
        float moveHorizontal = Input.GetAxis("LeftJoystickHorizontal");
        float moveVertical = Input.GetAxis("LeftJoystickVertical");

        // Calcular a direção de movimento
        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical);

        // Normalizar a direção de movimento para evitar movimento mais rápido nas diagonais
        moveDirection.Normalize();

        // Mover o objeto na direção do joystick
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
