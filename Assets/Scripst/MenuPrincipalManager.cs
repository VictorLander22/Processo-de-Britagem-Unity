using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField]
    private AudioManager aud;

    [SerializeField]
    private string nomeCena;

    [SerializeField]
    private GameObject painelMenuInicial;

    [SerializeField]
    private GameObject painelOpcoes;

    void Start()
    {
        // Procura pelo audio preservado entre as cenas
        aud = FindObjectOfType<AudioManager>();
        if (aud == null)
        {
            Debug.LogError("Aud null");
        }
    }

    public void abrir() // metodo do botao Abrir do menu
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void abrirOpcoes() // metodo chamado ao clicar em opcoes
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void fecharOpcoes()
    {
        aud.sounds[0].source.volume = aud.sounds[0].volume;

        for (short i = 1; i < (aud.sounds.Length - 1); i++)
        {
            aud.sounds[i].source.volume = aud.sounds[i].volume;
        }

        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void sair()
    {
        Debug.Log("Closing");
        Application.Quit();
    }

    public void slideMusica(float x)
    {
        if (aud.sounds != null && aud.sounds.Length > 0)
            aud.sounds[0].volume = x;
    }

    /**
     *
     * Mudar o volume dos equipamentos da planta. O vetor comeca em 1 e termina no numero maximo de sons diferentes dos equipamentos.
     * o 0 e do tema musical de fundo controlado pelo slideMusica.
     */
    public void slideVolume(float x)
    {
        if (aud.sounds != null && aud.sounds.Length > 0)
        {
            //Debug.Log("Length: " + (aud.sounds.Length - 1));
            for (short i = 1; i < (aud.sounds.Length - 1); i++)
            {
                aud.sounds[i].volume = x;
            }
        }
    }
}
