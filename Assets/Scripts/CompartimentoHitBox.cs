using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompartimentoHitBox : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            Vector3 velocidade = new Vector3(-0.5f, 0.5f, 0f);

            // Aplica a velocidade ao Rigidbody
            rigidbody.velocity = velocidade;
        }
    }
}
