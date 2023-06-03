using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPersonalClass : MonoBehaviour // classe autoral para destruir objetos no jogo.
//N confundir com os metodos destroy do propio Unity
{
    private const float destroyInterval = 60f; // Intervalo de tempo para destruir os objetos (3 minutos)
    private float lastDestroyTime = 0f; // Armazena o tempo da �ltima destrui��o

    // funcao para destruir todos os objetos com uma tag em especifica.
    public void DestroyObjectsWithTags(params string[] tags)
    {
        foreach (string tag in tags)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject obj in objectsWithTag)
            {
                Destroy(obj);
            }
        }
    }

    public void DestroyAllBritas()
    {
        DestroyObjectsWithTags("Brita1", "Brita2", "Brita3", "Brita4", "Brita5");
    }

    private void FixedUpdate()
    {
        if (Time.time - lastDestroyTime >= destroyInterval)
        {
            DestroyObjectsWithTags("Brita3", "Brita4", "Brita5");
            lastDestroyTime = Time.time;
        }
    }
}
