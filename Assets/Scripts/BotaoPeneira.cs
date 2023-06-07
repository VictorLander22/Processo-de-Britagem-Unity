using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoPeneira : MonoBehaviour
{
    public Com com;

    private void OnMouseDown() // Para cliques com o mouse
    {
        Action();
    }

    private void OnCollisionEnter(Collision other) // procura colisao com os controles vr
    {
        if (other.collider.gameObject.CompareTag("VR controller"))
        {
            Debug.LogWarning("Botao Liga Processo: Colisao detectada com VR controller");
            Action();
            // Faça alguma ação específica para a colisão com um objeto VR controller
        }
    }

    private void Action()
    {
        if (com.PlcWriteByte[0] >= 128)
        {
            if (com.vetorDeBits[3] == true)
            {
                com.PlcWriteByte[0] = (byte)(com.PlcWriteByte[0] - (64));

                if (!com.plc.IsConnected)
                    com.PlcReadByte[0] = (byte)(com.PlcReadByte[0] - (8));
            }
            else
            {
                com.PlcWriteByte[0] = (byte)(com.PlcWriteByte[0] + (64));

                if (!com.plc.IsConnected)
                    com.PlcReadByte[0] = (byte)(com.PlcReadByte[0] + (8));
            }
            com.plcWrite();
        }
    }
}
