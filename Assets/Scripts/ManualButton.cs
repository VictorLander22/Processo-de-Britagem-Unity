using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualButton : MonoBehaviour
{

 public Com com;

 private Renderer objectRenderer;

 private void Start()
    {
        // Obtém a referência ao componente Renderer
        objectRenderer = GetComponent<Renderer>();

    }
     private void OnMouseDown()
    {
        if(com.PlcWriteByte[0] < 128)
        {
       com.PlcWriteByte[0] = (byte) (com.PlcWriteByte[0] + 128);
        objectRenderer.material.color = Color.red; // automatico
        }
        else
        {
        com.PlcWriteByte[0]=(byte)(com.PlcWriteByte[0]- 128);
         objectRenderer.material.color = Color.green; // manual
        }

       com.plcWrite();
    }
}
