using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peneira : MonoBehaviour
{
    private GameObject peneira;
    // Start is called before the first frame update
    void Start()
    {
        peneira = GameObject.Find("Segunda-Britadeira");
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
        Animator anim = peneira.GetComponent<Animator>();
        anim.enabled = true;
        AnimationClip[] animationClips = anim.runtimeAnimatorController.animationClips;
        foreach(AnimationClip animClip in animationClips)
        {
            Debug.LogWarning(animClip.name);
            anim.Play(animClip.name);
        }
    }

    private void stopAnimations() {
        Animator anim = peneira.GetComponent<Animator>();
        anim.enabled = false;
    }


}
