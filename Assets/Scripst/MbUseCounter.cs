using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Metodo pra monitorar o uso de memoria RAM gasto pelo oculus com a execusao da cena.
public class MbUseCounter : MonoBehaviour
{
    private TextMeshProUGUI mText; // referência ao objeto Text que exibe o uso de memória

    void Start()
    {
        mText = GetComponent<TextMeshProUGUI>();
        InvokeRepeating(nameof(mbUpdate), 0.0f, 1f);
    }

    private void mbUpdate()
    {
        // obtém o tamanho da memória alocada em megabytes. A divisao por 104... e pra converter o valor byte para mega.
        float memoryUsed = UnityEngine.Profiling.Profiler.GetTotalReservedMemoryLong() / 1048576f;

        mText.text = memoryUsed.ToString("F2") + " MB"; 
    }
}
