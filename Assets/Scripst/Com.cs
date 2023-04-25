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

    public Image statusConexao;

    // Start is called before the first frame update
    void Start()
    {
        // Ip adrress :  192.168.0.1
        // SubnetMask = 255.255.255.0
        plc = new Plc(CpuType.S71200, ipAddress, rack, slot);
        plcConnect();
    }

    // Update is called once per frame
    void Update()
    {
        //DBX e uma boleana
        //DBW e para real

        if (plc.IsConnected)
        {
            //bool outputValue = (bool)plc.Read("DB1.DBX0.1");

            // string address = "DB1.DBX0.0";

            // // Escreve o valor booleano na variável especificada
            // plc.Write(address, value);
        }
        else
        {
            statusConexao = GameObject.Find("StatusConexaoObject").GetComponent<Image>();

            Color newColor = new Color(255f, 0f, 0f, 1f);
            statusConexao.color = newColor;
        }

        //   outputValue = plc.ReadBit(DataType.DataBlock, dbNumber, byteIndex, bitIndex);
    }

    public void plcConnect()
    {
        Debug.Log("Tentando Reconectar ao PLC...");

        statusConexao = GameObject.Find("StatusConexaoObject").GetComponent<Image>();

        try
        {
            plc.Open();

            if (plc.IsConnected)
            {
                Debug.Log("Conexão com PLC estabelecida");

                Color newColor = new Color(0f, 255f, 0f, 1f);
                statusConexao.color = newColor;
            }
            else
            {
                Debug.LogError("Não foi possível estabelecer conexão com PLC");

                Color newColor = new Color(255f, 0f, 0f, 1f);
                statusConexao.color = newColor;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Erro ao conectar ao PLC: " + ex.Message);

            Color newColor = new Color(255f, 0f, 0f, 1f);
            statusConexao.color = newColor;
        }
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
