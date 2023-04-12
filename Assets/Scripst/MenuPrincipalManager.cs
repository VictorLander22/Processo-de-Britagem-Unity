using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    [SerializeField]
    private Slider sliderMusic;

    [SerializeField]
    private Slider sliderVolum;

    private void Start()
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

        if (aud.sounds.Length > 0 && aud.sounds[1].source != null)
        {
            sliderMusic.value = aud.sounds[0].source.volume;
            sliderVolum.value = aud.sounds[1].source.volume; // como todos os equipamentos vao ter teoricamente o mesmo som ele. O slider pode recuperar o valor de um deles somente.
        }
    }

    public void fecharOpcoes()
    {
        aud.sounds[0].source.volume = aud.sounds[0].volume;
        foreach (Sound s in aud.sounds)
        {
            if (s == null || s.source == null)
                continue;

            // Armazena o volume atual do som
            float currentVolume = s.source.volume;

            // Define o volume do som como seu valor original
            s.source.volume = s.volume;

            // Define o volume do som como seu volume atual (para restaurar o valor original se o volume tiver sido alterado)
            s.source.volume = currentVolume;
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
            foreach (Sound s in aud.sounds)
            {
                if (s == null || s.source == null || s == aud.sounds[0])
                    continue;
                s.source.volume = x;
            }
        }
    }
}
