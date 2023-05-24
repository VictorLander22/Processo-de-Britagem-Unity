using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esteira : MonoBehaviour
{
    private GameObject esteira;

    private bool state = false;

    Transform filho;

    [SerializeField]
    private List<Rigidbody> britasColididas = new List<Rigidbody>(); // Lista de britas que entraram en contato com a esteira.

    [SerializeField]
    private float forcaEsteira = 1.0f;

    [SerializeField]
    private AudioManager aud;

    // Start is called before the first frame update
    void Start()
    {
        esteira = GameObject.Find("Esteira");

        // Procura pelo audio preservado entre as cenas
        aud = FindObjectOfType<AudioManager>();
        if (aud == null)
        {
            Debug.LogError("Aud null");
        }

        addRoletaColider();
    }

    // Update is called once per frame
    void Update()
    {
        AplicarForcaBrita();
    }

    public void ligar()
    {
        Debug.LogWarning("Esteira Ligada");
        startAnimations();
        state = true;
        aud.Play("Esteira");
    }

    public void parar()
    {
        stopAnimations();
        state = false;
        aud.Stop("Esteira");
    }

    private void startAnimations()
    {
        Animator[] childAnimators = esteira.GetComponentsInChildren<Animator>();
        foreach (Animator anim in childAnimators)
        {
            anim.enabled = true;
            AnimationClip[] animationClips = anim.runtimeAnimatorController.animationClips;
            foreach (AnimationClip animClip in animationClips)
            {
                anim.Play(animClip.name);
            }
        }
    }

    private void stopAnimations()
    {
        Animator[] childAnimators = esteira.GetComponentsInChildren<Animator>();
        foreach (Animator anim in childAnimators)
        {
            if (anim.enabled)
            {
                anim.enabled = false;
            }
        }
    }

    private void addRoletaColider()
    {
        filho = transform.Find("Roleta");

        if (filho != null)
        {
            // Obtém o MeshCollider do objeto filho encontrado
            MeshCollider meshCollider = filho.GetComponent<MeshCollider>();

            if (meshCollider != null)
            {
                // Faça algo com o MeshCollider
                Debug.Log("MeshCollider encontrado no objeto filho ");
            }
            else
            {
                Debug.Log("Nenhum MeshCollider encontrado no objeto filho ");
            }
        }
        else
        {
            Debug.Log("Nenhum objeto filho com o nome  encontrado.");
        }
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     // Verifica se o objeto colidiu com o objeto da esteira
    //     if (collision.gameObject.CompareTag("Brita2"))
    //     {
    //         Debug.LogWarning("Brita2 colidiu com o hit box");

    //         // Obtém o componente Rigidbody do objeto colidido
    //         Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();

    //         // Verifica se o objeto possui um Rigidbody
    //         if (rigidbody != null)
    //         {
    //             Debug.LogWarning("1");
    //             // Adiciona o Rigidbody à lista de objetos colididos
    //             britasColididas.Add(rigidbody);
    //         }
    //     }
    // }

    // Mover brita
    public void AplicarForcaBrita()
    {
        foreach (Rigidbody brita in britasColididas)
        {
            if (brita != null)
            {
                // Aplica a força no objeto ao longo do eixo X positivo
                brita.AddForce(Vector3.left * forcaEsteira);
            }
        }
    }
}
