using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoBritadorPrimario : MonoBehaviour
{
    public BritadorPrimario britador1;

    public Com com;
    private void OnMouseDown()
    {
        britador1.ligar();

        com.vetorDeBits[0] = !com.vetorDeBits[0];
        com.plcWrite();
    }
}
