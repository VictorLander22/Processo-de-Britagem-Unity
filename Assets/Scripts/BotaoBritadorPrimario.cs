using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoBritadorPrimario : MonoBehaviour
{
    public BritadorPrimario Britador;

    public Com com;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    private void OnMouseDown()
    {
        Britador.ligar();

        com.vetorDeBits[0] = 1;
        com.plcWrite();
    }
}
