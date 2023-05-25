using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoletaHitBox : MonoBehaviour
{
    public List<Rigidbody> britasColididas = new List<Rigidbody>(); // Lista de britas que entraram em contato com a esteira.

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brita2"))
        {
            Debug.LogWarning("Esteira: Brita2 colidiu com o hit box");

            // Obtém o componente Rigidbody do objeto colidido
            if (collision.gameObject.TryGetComponent(out Rigidbody rigidbody))
            {
                // Verifica se o objeto já está na lista
                if (!britasColididas.Contains(rigidbody))
                {
                    // Adiciona o Rigidbody à lista de britas colididas
                    britasColididas.Add(rigidbody);
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brita2"))
        {
            Debug.LogWarning("Esteira: Brita2 saiu do hit box");

            // Obtém o componente Rigidbody do objeto que saiu de contato
            if (collision.gameObject.TryGetComponent(out Rigidbody rigidbody))
            {
                // Remove o Rigidbody da lista de britas colididas
                britasColididas.Remove(rigidbody);
            }
        }
    }

    public void LimparListaBritas()
    {
        britasColididas.Clear();
    }
}
