using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoPeneira : MonoBehaviour
{
    public Peneira peneira1;

    public Com com;
    private void OnMouseDown()
    {
        peneira1.ligar();

        com.vetorDeBits[2] = !com.vetorDeBits[2];
        com.plcWrite();
    }
}
