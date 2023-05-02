using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BritadorPrimario : MonoBehaviour
{
    [SerializeField]
    private AudioManager aud;

    // Start is called before the first frame update
    void Start()
    {
        // Procura pelo audio preservado entre as cenas
        aud = FindObjectOfType<AudioManager>();
        if (aud == null)
        {
            Debug.LogError("Aud null");
        }
    }

    // Update is called once per frame
    void Update() { }

    /**
     *Nesse metodo que vao estar todas as coisas chamadas quando o britador for acionado.
     **/
    public void ligar()
    {
        Debug.LogWarning("Britador Ligado");

        aud.Play("Britador");

        // aud.Play("Esteira");
    }

    public void parar()
    {
        aud.Stop("Britador");
    }
}
