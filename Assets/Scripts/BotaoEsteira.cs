using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoEsteira : MonoBehaviour
{
    public Esteira esteira1;

    public Com com;
    private void OnMouseDown()
    {
        esteira1.ligar();

        com.vetorDeBits[1] = !com.vetorDeBits[1];
        com.plcWrite();
    }
}
