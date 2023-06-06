using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergenciaButton : MonoBehaviour
{
    [SerializeField]
    private Com com;

    [SerializeField]
    private DestroyPersonalClass dest1;

    [SerializeField]
    private RoletaHitBox roleta1;

    private void OnMouseDown()
    {
        com.EmergenciaProcesso();
        roleta1.LimparListaBritas();
        dest1.DestroyAllBritas();

        if(!com.plc.IsConnected)
            com.PlcReadByte[0]=0;
    }
}
