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
    private GameObject painelMenuInicial;

    [SerializeField]
    private GameObject painelOpcoes;

    [SerializeField]
    private Slider sliderMusic;

    [SerializeField]
    private Slider sliderVolum;

    [SerializeField]
    private CameraController controle;

    private void Start()
    {
        // Procura pelo objeto de audio preservado entre as cenas
        aud = FindObjectOfType<AudioManager>();
        if (aud == null)
        {
            Debug.LogError("Aud null");
        }

        //Exclusivo para a quando for a BUILD. Nao funciona pro PLAYMODE(teste) do UNITY
        // Recupera o valor do slider de música salvo na memoria, quando for reabrir a aplicacao do UNITY.
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            float savedMusicVolume = PlayerPrefs.GetFloat("musicVolume");
            sliderMusic.value = savedMusicVolume;
            slideMusica(savedMusicVolume);
        }

        // Recupera o valor do slider de volume salvo na memoria
        if (PlayerPrefs.HasKey("soundVolume"))
        {
            float savedSoundVolume = PlayerPrefs.GetFloat("soundVolume");
            sliderVolum.value = savedSoundVolume;
            slideVolume(savedSoundVolume);
        }
    }

    public void abrir(string nomeCena) // metodo do botao Abrir do menu
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void abrirOpcoes() // metodo chamado ao clicar em opcoes
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);

        if (aud.sounds.Length > 0 && aud.sounds[1].source != null)
        {
            sliderMusic.value = aud.sounds[0].source.volume; // musica
            sliderVolum.value = aud.sounds[1].source.volume; // equipamentos
        }
    }

    public void fecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void sair()
    {
        Debug.Log("Closing");
        Application.Quit();
    }

    public void slideMusica(float slideValue)
    {
        if (
            aud != null
            && aud.sounds != null
            && aud.sounds.Length > 0
            && aud.sounds[0] != null
            && aud.sounds[0].source != null
        )
        {
            aud.sounds[0].volume = slideValue;
            aud.sounds[0].source.volume = slideValue;

            //So funciona em caso de ser a BUILD
            PlayerPrefs.SetFloat("musicVolume", slideValue);
            PlayerPrefs.Save();
        }
    }

    /**
   *
   * Mudar o volume dos equipamentos da planta. O vetor comeca em 1 e termina no numero maximo de sons diferentes dos equipamentos.
   * o 0 e do tema musical de fundo controlado pelo slideMusica.
   */
    public void slideVolume(float slideValue)
    {
        if (
            aud != null
            && aud.sounds != null
            && aud.sounds.Length > 0
            && aud.sounds[0] != null
            && aud.sounds[0].source != null
        )
        {
            foreach (Sound s in aud.sounds)
            {
                if (s == null || s.source == null || s == aud.sounds[0])
                    continue;
                s.source.volume = slideValue;
                s.volume = slideValue;
            }
            //So funciona em caso de ser a BUILD
            PlayerPrefs.SetFloat("soundVolume", slideValue);
            PlayerPrefs.Save();
        }
    }
}
