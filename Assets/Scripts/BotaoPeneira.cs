using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoPeneira : MonoBehaviour
{
    public Com com;

    private void OnMouseDown()
    {
       if(com.PlcWriteByte[0] >= 128) {
            if (com.vetorDeBits[3] == true){
            com.PlcWriteByte[0]= (byte)(com.PlcWriteByte[0] -(64));

               if(!com.plc.IsConnected)
             com.PlcReadByte[0]=(byte)(com.PlcReadByte[0] -(8));
        } else
        {
            com.PlcWriteByte[0]=(byte)(com.PlcWriteByte[0] +(64));

               if(!com.plc.IsConnected)
             com.PlcReadByte[0]=(byte)(com.PlcReadByte[0] +(8));

        }
        com.plcWrite();
        }
    }
}
