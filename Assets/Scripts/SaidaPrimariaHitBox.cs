using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaidaPrimariaHitBox : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            Vector3 velocidade = new Vector3(-3f, 0f, 0f);

            // Aplica a velocidade ao Rigidbody
            rigidbody.velocity = velocidade;
        }
    }
}
