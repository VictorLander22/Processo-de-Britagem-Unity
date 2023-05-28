using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoLigaProcesso : MonoBehaviour
{
    [SerializeField]
    private Com com;

    private void OnMouseDown()
    {
        com.britador1.ligar();
        com.esteira1.ligar();
        com.peneira1.ligar();

        com.vetorDeBits[0] = true;
        com.vetorDeBits[1] = true;
        com.vetorDeBits[2] = true;

        com.plcWrite();
    }
}
