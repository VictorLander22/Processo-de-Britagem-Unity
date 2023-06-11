using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alimentador : MonoBehaviour
{

    [SerializeField]
    private GameObject alimentador;

    void Start()
    {
        alimentador = GameObject.Find("Alimentador");
    }

    public void ligar()
    {
        Debug.LogWarning("Alimentador Ligado");
        startAnimations();
    }

    public void parar()
    {
       stopAnimations();
    }

    private void startAnimations()
    {
        Animator anim = alimentador.GetComponent<Animator>();
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
        Animator anim = alimentador.GetComponent<Animator>();
        if (anim.enabled)
        {
            anim.enabled = false;
        }
    }

}