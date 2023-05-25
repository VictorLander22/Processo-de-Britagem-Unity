using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peneira : MonoBehaviour
{
    private GameObject peneira;

    private bool ligado = false;
    private List<GameObject> britasColididas = new List<GameObject>(); // Lista de britas que colidiram com a peneira

    [SerializeField]
    private AudioManager aud;

    [SerializeField]
    private Cena1Manager cena1;

    // Start is called before the first frame update
    void Start()
    {
        peneira = GameObject.Find("Peneira");

        // Procura pelo audio preservado entre as cenas
        aud = FindObjectOfType<AudioManager>();
        if (aud == null)
        {
            Debug.LogError("Aud null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        colisaoOcorrendo();
    }

    public void ligar()
    {
        Debug.LogWarning("Peneira Ligada");
        startAnimations();
        ligado = true;
        aud.Play("Peneira");
    }

    public void parar()
    {
        stopAnimations();
        ligado = false;
        aud.Stop("Peneira");
    }

    private void startAnimations()
    {
        Animator anim = peneira.GetComponent<Animator>();
        anim.enabled = true;
        AnimationClip[] animationClips = anim.runtimeAnimatorController.animationClips;
        foreach (AnimationClip animClip in animationClips)
        {
            Debug.LogWarning(animClip.name);
            anim.Play(animClip.name);
        }
    }

    private void stopAnimations()
    {
        Animator anim = peneira.GetComponent<Animator>();
        if (anim.enabled)
        {
            anim.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brita2"))
        {
            Debug.LogWarning("Peneira :Brita colidiu");
            britasColididas.Add(collision.gameObject);
        }
    }

    private void colisaoOcorrendo()
    {
        if (britasColididas.Count > 0 && ligado == true)
        {
            foreach (GameObject brita in britasColididas)
            {
                Debug.LogWarning(" Peneira: Vou destrui a brita");
                Destroy(brita);
                StartCoroutine(cena1.SpawnBrita3());
                StartCoroutine(cena1.SpawnBrita4());
            }
            britasColididas.Clear();
        }
    }
}
