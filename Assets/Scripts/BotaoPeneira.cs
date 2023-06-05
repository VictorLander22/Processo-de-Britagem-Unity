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
        } else
            com.PlcWriteByte[0]=(byte)(com.PlcWriteByte[0] +(64));
        com.plcWrite();
        }
    }
}
