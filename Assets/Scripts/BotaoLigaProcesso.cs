using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// using UnityEngine.XR.Interaction.Toolkit;

public class BotaoLigaProcesso : MonoBehaviour
{
    [SerializeField]
    private Com com;

    private void OnMouseDown() // Para cliques com o mouse
    {
        Debug.LogWarning("Liga Processo: passei pelo OnMouseDown");
        Action();
    }

    public void Action()
    {
        if (!com.plc.IsConnected)
            com.PlcReadByte[0] = 15;

        com.LigarProcesso();
    }
}
