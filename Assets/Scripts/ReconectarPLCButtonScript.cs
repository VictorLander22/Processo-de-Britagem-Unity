using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReconectarPLCButtonScript : MonoBehaviour
{
    public Com com;

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
        com.clickplcReConnect();
    }
}
