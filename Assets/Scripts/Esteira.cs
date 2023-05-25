using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esteira : MonoBehaviour
{
    private GameObject esteira;

    private bool ligado = false;

    public RoletaHitBox roleta;

    [SerializeField]
    private float velocidadeEsteiraX = 1.0f;

    [SerializeField]
    private float velocidadeEsteiraY = 1.0f;

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
        AplicarVelocidadeBrita();
    }

    public void ligar()
    {
        Debug.LogWarning("Esteira: Ligada");
        startAnimations();
        ligado = true;
        aud.Play("Esteira");
    }

    public void parar()
    {
        stopAnimations();
        ligado = false;
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
        Transform filho = transform.Find("Roleta");

        if (filho != null)
        {
            roleta = filho.GetComponent<RoletaHitBox>();
        }
        else
        {
            Debug.Log("Esteira: Nenhum objeto filho com o nome  encontrado.");
        }
    }

    // Mover brita
    // o valor de velocidadeEsteira e multiplicado por negativo pois o sentido de locomocao e no sentido inverso do eixo X.
    //De x 0 para x -1 e assim por diante
    public void AplicarVelocidadeBrita()
    {
        if (roleta == null)
            return;

        if (ligado == false)
            return;

        // foreach (Rigidbody brita in roleta.britasColididas)
        // {
        //     if (brita != null)
        //     {
        //         // Define a velocidade constante no eixo X positivo
        //         Vector3 velocidade = new Vector3(-velocidadeEsteira, 0, 0);

        //         // Move o objeto usando a velocidade constante
        //         brita.MovePosition(brita.position + velocidade * Time.deltaTime);


        //     }
        // }

        foreach (Rigidbody brita in roleta.britasColididas)
        {
            if (brita != null)
            {
                // Define a velocidade constante no eixo X positivo
                Vector3 velocidade = new Vector3(-velocidadeEsteiraX, velocidadeEsteiraY, 0);

                brita.velocity = velocidade;
            }
        }
    }
}
