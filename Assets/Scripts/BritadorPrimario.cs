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

    private bool state = false; // armazena o estado atual do britador. Ligado = True, Desl = False

    private GameObject britaColidida;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        colisaoOcorrendo();
    }

    /**
     *Nesse metodo que vao estar todas as coisas chamadas quando o britador for acionado.
     **/
    public void ligar()
    {
        Debug.LogWarning("Britador Ligado");

        startAnimations();
        state = true;
        aud.Play("Britador");
    }

    public void parar()
    {
        stopAnimations();
        state = false;
        aud.Stop("Britador");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brita1"))
        {
            Debug.LogWarning("Brita colidiu com o britador1");
            britaColidida = collision.gameObject;
        }
    }

    private void colisaoOcorrendo()
    {
        if (britaColidida != null && state == true)
        {
            Destroy(britaColidida);
            StartCoroutine(cena1.SpawnBrita2());
        }
    }

    // private IEnumerator OnCollisionStay(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Brita1"))
    //     {
    //         Debug.LogWarning("Brita esta em contato com hit box");

    //         if (state == true)
    //         {
    //             yield return new WaitForSeconds(0.5f);
    //             Destroy(collision.gameObject);
    //         }
    //     }
    // }

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
