using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoEsteira : MonoBehaviour
{
 
    public Com com;
    private void OnMouseDown()
    {
        com.esteira1.ligar();

        com.vetorDeBits[1] = !com.vetorDeBits[1];
        com.plcWrite();
    }
}
