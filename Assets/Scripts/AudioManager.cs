using UnityEngine.Audio;
using UnityEngine;
using System;

[System.Serializable]
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Start()
    {
        Play("Zelda");
    }

    /// Awake is called when the script instance is being loaded.
    void Awake()
    {
        // garante que n vai carregar mais de uma lista de arquivos de som
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Esta causando um bug sair e voltar a cena de menu principal.Retorna NullException.
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Update is called once per frame
    void Update() { }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) // verifica se consegue achar um arquivo com o nome de sim correto
        {
            Debug.LogWarning("Som " + name + "Nao encontrado");
            return;
        }
        if (s.source.isPlaying) // verifica se o som ja esta em reproducao e caso sim nao o inicia novamente
            return;
        s.source.Play(); // vai dar erro se o name estiver incorreto
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) // verifica se consegue achar um arquivo com o nome de sim correto
        {
            Debug.LogWarning("Som " + name + "Nao encontrado");
            return;
        }
        s.source.Stop();
    }
}