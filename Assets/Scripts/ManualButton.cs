using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualButton : MonoBehaviour
{

     public Com com;


     private void OnMouseDown()
    {
        if(com.PlcWriteByte[0] < 128)
        {
         com.PlcWriteByte[0] = (byte) (com.PlcWriteByte[0] + 128);
        }
        else
        {
         com.PlcWriteByte[0]=(byte)(com.PlcWriteByte[0]- 128);
        }
       
       com.plcWrite();
    }
}
