using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peneira : MonoBehaviour
{
    private GameObject peneira;

    [SerializeField]
    private AudioManager aud;

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
    void Update() { }

    public void ligar()
    {
        Debug.LogWarning("Peneira Ligada");
        startAnimations();
        aud.Play("Peneira");
    }

    public void parar()
    {
        stopAnimations();
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
}
