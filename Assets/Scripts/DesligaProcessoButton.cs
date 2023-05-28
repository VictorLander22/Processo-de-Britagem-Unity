using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesligaProcessoButton : MonoBehaviour
{
    [SerializeField]
    private Com com;

    private void OnMouseDown()
    {
        com.britador1.parar();
        com.esteira1.parar();
        com.peneira1.parar();

        com.vetorDeBits[0] = false;
        com.vetorDeBits[1] = false;
        com.vetorDeBits[2] = false;

        com.plcWrite();
    }
}