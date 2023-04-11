using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Codigo pra calcular e mostrar a taxa de atualizacao da imagem na tela 
public class FpsCounter : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

        InvokeRepeating(nameof(FpsCalc), 0.0f, 1f);
    }

    // Update is called once per frame
    void Update() { }

    private void FpsCalc()
    {
        textMesh.text = (1f / Time.deltaTime).ToString("00") + " FPS";
    }
}
