using UnityEngine;

public class CameraTeclado : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 50f;

    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }

    void Update()
    {
        // Movimento para cima
        if (Input.GetKey(KeyCode.W))
        {
            myTransform .Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // Movimento para baixo
        if (Input.GetKey(KeyCode.S))
        {
            myTransform .Translate(Vector3.back * speed * Time.deltaTime);
        }

        // Movimento para a esquerda
        if (Input.GetKey(KeyCode.A))
        {
            myTransform .Translate(Vector3.left * speed * Time.deltaTime);
        }

        // Movimento para a direita
        if (Input.GetKey(KeyCode.D))
        {
            myTransform .Translate(Vector3.right * speed * Time.deltaTime);
        }

        // Rotação para a esquerda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myTransform .Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        // Rotação para a direita
        if (Input.GetKey(KeyCode.RightArrow))
        {
            myTransform .Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Rotação para cima
        if (Input.GetKey(KeyCode.UpArrow))
        {
            myTransform .Rotate(Vector3.right, -rotationSpeed * Time.deltaTime);
        }

        // Rotação para baixo
        if (Input.GetKey(KeyCode.DownArrow))
        {
            myTransform .Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
    }
}
