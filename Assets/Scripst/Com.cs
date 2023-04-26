using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using S7.Net;
using S7.Net.Types;
using System;
using UnityEngine.UI;
using System.Threading;

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

    private Thread plcThread;

    // Start is called before the first frame update
    void Start()
    {
        // Ip adrress :  192.168.0.1
        // SubnetMask = 255.255.255.0
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

            SetConnectionStatusColor(Color.red);
        }

        //   outputValue = plc.ReadBit(DataType.DataBlock, dbNumber, byteIndex, bitIndex);
    }

    /**
    *Conexao executada em thread separada pra evitar que o programa fique travado durante o processo.
    */
    public void plcConnect()
    {
        Debug.LogWarning("Tentando conectar ao PLC...");
        plcThread = new Thread(() =>
        {
            try
            {
                using (plc = new Plc(CpuType.S71200, ipAddress, rack, slot))
                {
                    plc.Open();
                    if (plc.IsConnected)
                    {
                        Debug.Log("Conexão com PLC estabelecida");
                        SetConnectionStatusColor(Color.green);
                    }
                    else
                    {
                        throw new Exception("Não foi possível estabelecer conexão com PLC");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Erro ao conectar ao PLC: " + ex.Message);
                SetConnectionStatusColor(Color.red);
            }
        });
        plcThread.Start();
    }

    public void ToggleInput()
    {
        estado = !estado; // inverte o estado entre true e false.
    }

    public void StopConnection()
    {
        if (plc != null && plc.IsConnected)
        {
            plc.Close();
        }
    }

    private void OnDestroy()
    {
        if (plc != null && plc.IsConnected)
        {
            plc.Close();
        }
    }

    // mudar a cor relativo aos status de conexao
    private void SetConnectionStatusColor(Color color)
    {
        statusConexao.color = color;
    }
}
