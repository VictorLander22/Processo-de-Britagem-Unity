using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// using UnityEngine.XR.Interaction.Toolkit;

public class BotaoLigaProcesso : MonoBehaviour
{
    [SerializeField]
    private Com com;

    //  [SerializeField]
    //  private List<XRDirectInteractor> interactors = new List<XRDirectInteractor>();

    private void OnMouseDown() // Para cliques com o mouse
    {
        Action();
    }

    private void OnCollisionEnter(Collision other) // procura colisao com os controles vr
    {
        if (other.collider.gameObject.CompareTag("VR controller"))
        {
            Debug.LogWarning("Botao Liga Processo: Colisao detectada com VR controller");
            Action();
            // Faça alguma ação específica para a colisão com um objeto VR controller
        }
    }

    private void Action()
    {
        // com.britador1.ligar();
        //  com.esteira1.ligar();
        //  com.peneira1.ligar();
        if (!com.plc.IsConnected)
            com.PlcReadByte[0] = 15;

        com.LigarProcesso();
    }
    // private void OnTriggerEnter(Collider other)
    // {
    //     foreach (XRDirectInteractor interactor in interactors)
    //     {
    //         if (interactor.GetComponent<Collider>() == other)
    //         {
    //           Action();
    //         }
    //     }
    // }
}
