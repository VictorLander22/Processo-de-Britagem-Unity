using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// codigo para colocar uma velocidade horizontal na brita quando ela for sair da peneira . Sem isso ela fica estatica
public class SaidasPeneira : MonoBehaviour
{
    public float velocidadeBrita = 1.0f;
    private Vector3 velocidade;

    void Awake()
    {
        velocidade = new Vector3(-velocidadeBrita, 0f, 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.velocity = velocidade;
        }
    }
}
