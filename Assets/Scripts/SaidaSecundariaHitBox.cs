using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaidaSecundariaHitBox : MonoBehaviour
{
    
    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            Vector3 velocidade = new Vector3(-4f, 0f, 0f);

            // Aplica a velocidade ao Rigidbody
            rigidbody.velocity = velocidade;
        }
    }
}
