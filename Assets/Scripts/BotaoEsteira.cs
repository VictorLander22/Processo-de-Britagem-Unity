using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoEsteira : MonoBehaviour
{
 
    public Com com;
    private void OnMouseDown()
    {
     if(com.PlcWriteByte[0] >= 128) {
            if (com.vetorDeBits[2] == true){
            com.PlcWriteByte[0]= (byte)(com.PlcWriteByte[0] -(32));
        } else
            com.PlcWriteByte[0]=(byte)(com.PlcWriteByte[0] +(32));
        com.plcWrite();
        }
    }
}
