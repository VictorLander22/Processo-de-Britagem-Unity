using UnityEngine;

public class CameraTeclado : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 50f;

    void Update()
    {
        // Movimento para cima
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // Movimento para baixo
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        // Movimento para a esquerda
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        // Movimento para a direita
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

         // Rotação para a esquerda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        // Rotação para a direita
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Rotação para cima
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right, -rotationSpeed * Time.deltaTime);
        }

        // Rotação para baixo
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
    }
}
