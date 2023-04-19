using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using S7.Net;
using S7.Net.Types;
using System;
using UnityEngine.UI;

// comunica com as DBs

public class Com : MonoBehaviour
{
    [SerializeField]
    private string ipAddress = "192.168.0.1";

    [SerializeField]
    private short rack = 0;

    [SerializeField]
    private short slot = 1;

    Plc plc;

    private bool estado;

    // Start is called before the first frame update
    void Start()
    {
        // Ip adrress :  192.168.0.1
        // SubnetMask = 255.255.255.0
        plc = new Plc(CpuType.S71200, ipAddress, rack, slot);
        plc.Open();

        if (plc.IsConnected)
        {
            Debug.Log("Conexão com PLC estabelecida");
        }
        else
        {
            Debug.LogError("Não foi possível estabelecer conexão com PLC");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //DBX e uma boleana
        //DBW e para real

        if (plc.IsConnected)
        {
            bool outputValue = (bool)plc.Read("DB1.DBX0.1");

            // string address = "DB1.DBX0.0";

            // // Escreve o valor booleano na variável especificada
            // plc.Write(address, value);
        }

        //   outputValue = plc.ReadBit(DataType.DataBlock, dbNumber, byteIndex, bitIndex);
    }
    
    public void ToggleInput()
    {
        estado = !estado; // inverte o estado entre true e false.
    }

    public void StopConnection()
    {
        plc.Close();
    }

    private void OnDestroy()
    {
        plc.Close();
    }
}
