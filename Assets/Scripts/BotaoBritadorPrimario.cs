using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoBritadorPrimario : MonoBehaviour
{
   
    public Com com;

    private void OnMouseDown()
    {
        if(com.PlcWriteByte[0] >= 128) {
            if (com.vetorDeBits[1] == true){
            com.PlcWriteByte[0]= (byte)(com.PlcWriteByte[0] -(16));

            if(!com.plc.IsConnected)
            com.PlcReadByte[0]=(byte)(com.PlcReadByte[0] -(2));

        } else
        {
            com.PlcWriteByte[0]=(byte)(com.PlcWriteByte[0] +(16));

            if(!com.plc.IsConnected)
             com.PlcReadByte[0]=(byte)(com.PlcReadByte[0] +(2));
        }
        com.plcWrite();
        }
    }
}
