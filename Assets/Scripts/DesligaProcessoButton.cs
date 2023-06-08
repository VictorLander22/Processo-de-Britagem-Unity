using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesligaProcessoButton : MonoBehaviour
{
    [SerializeField]
    private Com com;

    private void OnMouseDown() // Para cliques com o mouse
    {
        Action();
    }

    //  private void OnCollisionEnter(Collision other) // procura colisao com os controles vr
    //  {
    //    if (other.collider.gameObject.CompareTag("VR controller"))
    // {
    //Debug.LogWarning("Botao Liga Processo: Colisao detectada com VR controller");
    //          Action();
    // Faça alguma ação específica para a colisão com um objeto VR controller
    //    }
    //}

    public void Action()
    {
        //  com.britador1.parar();
        // com.esteira1.parar();
        // com.peneira1.parar();
        if (!com.plc.IsConnected)
            com.PlcReadByte[0] = 0;
        com.DesligaProcesso();
    }
}
