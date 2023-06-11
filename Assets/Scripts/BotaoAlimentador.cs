using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoAlimentador : MonoBehaviour
{
    public Com com;

    private void OnMouseDown() // Para cliques com o mouse
    {
        Action();
    }

    public void Action()
    {
        if (com.PlcWriteByte[0] >= 128)
        {
            if (com.vetorDeBits[0] == true)
            {
                com.PlcWriteByte[0] = (byte)(com.PlcWriteByte[0] - (8));

                if (!com.plc.IsConnected)
                    com.PlcReadByte[0] = (byte)(com.PlcReadByte[0] - (1));
            }
            else
            {
                com.PlcWriteByte[0] = (byte)(com.PlcWriteByte[0] + (8));

                if (!com.plc.IsConnected)
                    com.PlcReadByte[0] = (byte)(com.PlcReadByte[0] + (1));
            }
            com.plcWrite();
        }
    }
}
