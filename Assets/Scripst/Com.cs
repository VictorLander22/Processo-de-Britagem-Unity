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
        plc = new Plc(CpuType.S71200, ipAddress, rack, slot);
         statusConexao = GameObject.Find("StatusConexaoObject").GetComponent<Image>();
        plcConnect(plc);

    }

    // Update is called once per frame
    void Update()
    {
        //DBX e uma boleana
        //DBW e para real
       // Debug.Log("plc:"+plc.IsConnected);
        if (plc.IsConnected)
        {
            Debug.LogWarning("PLC conectado");
            
          //  bool outputValue = (bool)plc.Read("DB0.DBX0.0");
           // Debug.LogWarning(outputValue);
            // Verifica se a variável existe no PLC
      
       
        ///bool valorEntrada = (bool)plc.Read(DataType.DataBlock, 1, 0, VarType.Byte, 1, 0);
        //byte[] a = plc.ReadBytes(DataType.Output, 0, 0, 1);
        //Debug.LogWarning("Saida: "+ a[0].ToString());
        byte[] a = new byte[];
        plc.WriteBytes(DataType.Output, 0, 0, 1);
        byte[] b = plc.ReadBytes(DataType.Input, 0, 0, 1);
        Debug.LogWarning("Entrada 0: "+ b[0].ToString());

        

        //plc.Close(); // fecha a conexão com o PLC
           // Debug.LogWarning(plc.Read(DataType.Input, 0, 1, VarType.Bit, 1));
            //if(outputValue)
            //Debug.Log("plc: True");
            // string address = "DB1.DBX0.0";

            // // Escreve o valor booleano na variável especificada
            // plc.Write(address, value);
        }
        else
        {
           
           // SetConnectionStatusColor(Color.red);
        }

        //   outputValue = plc.ReadBit(DataType.DataBlock, dbNumber, byteIndex, bitIndex);
    }

    /**
    *Conexao executada em thread separada pra evitar que o programa fique travado durante o processo.
    */
public void plcConnect(Plc plc)
{
    Debug.LogWarning("Tentando conectar ao PLC...");
    plcThread = new Thread(() =>
    {
        try
        {
            // using (plc = new Plc(CpuType.S71200, ipAddress, rack, slot))
            {
                plc.Open();
               
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Erro ao conectar ao PLC: " + ex.Message);
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
