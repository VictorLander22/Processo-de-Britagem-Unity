using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esteira : MonoBehaviour
{

    private GameObject esteira; 

    // Start is called before the first frame update
    void Start()
    {
        esteira = GameObject.Find("Terceira-Britadeira");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ligar()
    {
        startAnimations();
    }

    public void parar()
    {
        stopAnimations();
    }

    private void startAnimations() {
        Animator[] childAnimators = esteira.GetComponentsInChildren<Animator>();
        foreach(Animator anim in childAnimators){
            anim.enabled = true;
            AnimationClip[] animationClips = anim.runtimeAnimatorController.animationClips;
            foreach(AnimationClip animClip in animationClips)
            {
                anim.Play(animClip.name);
            }
        }
    }

    private void stopAnimations() {
        Animator[] childAnimators = esteira.GetComponentsInChildren<Animator>();
        foreach(Animator anim in childAnimators){
            anim.enabled = false;
        }
    }

}
