using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esteira : MonoBehaviour
{
    private GameObject esteira;

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
    }

    // Update is called once per frame
    void Update() { }

    public void ligar()
    {
        Debug.LogWarning("Esteira Ligada");
        startAnimations();
        aud.Play("Esteira");
    }

    public void parar()
    {
        stopAnimations();
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
}
