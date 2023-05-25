using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPersonalClass : MonoBehaviour // classe autoral para destruir objetos no jogo.
//N confundir com os metodos destroy do propio Unity
{
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
        DestroyObjectsWithTags("Brita1", "Brita2", "Brita3", "Brita4");
    }
}
