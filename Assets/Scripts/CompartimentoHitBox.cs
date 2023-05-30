using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompartimentoHitBox : MonoBehaviour
{
    private Vector3 velocidade;

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            velocidade = new Vector3(-0.5f, 0.5f, 0f);

            // Aplica a velocidade ao Rigidbody
            rigidbody.velocity = velocidade;
        }
    }
}
