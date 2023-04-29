using System.Security.Cryptography.X509Certificates;
using System.IO.Enumeration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="collision">The Collision data associated with this collision.</param>

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terreno"))
        {
            
            FindObjectOfType<AudioManager>().Play("Britador");
            Destroy(gameObject);
        }
    }
}
