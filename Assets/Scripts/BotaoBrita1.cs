using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoBrita1 : MonoBehaviour
{
    [SerializeField]
    public Cena1Manager cena1Manager;

    void OnMouseDown()
    {
        Debug.LogWarning("Cliquei botao");
        StartCoroutine(cena1Manager.SpawnBrita1());
    }
}
