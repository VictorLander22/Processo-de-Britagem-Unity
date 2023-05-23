using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoBrita1 : MonoBehaviour
{
    [SerializeField]
    public Cena1Manager cena1;

    void OnMouseDown()
    {
        Debug.LogWarning("Cliquei botao");
        StartCoroutine(cena1.SpawnBrita1());
    }
}
