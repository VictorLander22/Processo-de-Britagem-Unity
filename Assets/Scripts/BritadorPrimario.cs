using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BritadorPrimario : MonoBehaviour
{
    private GameObject britador;

    [SerializeField]
    private Cena1Manager cena1;

    [SerializeField]
    private AudioManager aud;

    private bool ligado = false; // armazena o estado atual do britador. Ligado = True, Desl = False

    private GameObject britaColidida;

    void Start()
    {
        britador = GameObject.Find("Britadeira");

        // Procura pelo audio preservado entre as cenas
        aud = FindObjectOfType<AudioManager>();
        if (aud == null)
        {
            Debug.LogError("Aud null");
        }
    }

    void Update()
    {
        colisaoOcorrendo();
    }

    /**
     *Nesse metodo que vao estar todas as coisas chamadas quando o britador for acionado.
     **/
    public void ligar()
    {
        Debug.LogWarning("Britador: Ligado");

        startAnimations();
        ligado = true;
        aud.Play("Britador");
    }

    public void parar()
    {
        stopAnimations();
        ligado = false;
        aud.Stop("Britador");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brita1"))
        {
            Debug.LogWarning("Britador:Brita colidiu");
            britaColidida = collision.gameObject;
        }
    }

    private void colisaoOcorrendo()
    {
        if (britaColidida != null && ligado == true)
        {
            Destroy(britaColidida);
            StartCoroutine(cena1.SpawnBrita2());
        }
    }

    private void startAnimations()
    {
        Animator[] childAnimators = britador.GetComponentsInChildren<Animator>();
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
        Animator[] childAnimators = britador.GetComponentsInChildren<Animator>();
        foreach (Animator anim in childAnimators)
        {
            if (anim.enabled)
            {
                anim.enabled = false;
            }
        }
    }
}
