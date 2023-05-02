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

    public Image statusConexao;

    private Thread plcThread;

    // intervalo de tempo de leitura do plc
    public float intervaloDeTempo = 3.0f; // tempo da leitura de dados do plc
    private float ultimaExecucao = 0.0f;

    // intervalo de tempo de leitura do plc
    public byte myByte = 0;
    public byte[] vetorDeBits = new byte[8];

    // Objetos da planta

    public BritadorPrimario britador1;

    // Objetos da planta

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
        if (plc.IsConnected)
        {
            Debug.LogWarning("PLC conectado");

            //  bool outputValue = (bool)plc.Read("DB0.DBX0.0");
            // Debug.LogWarning(outputValue);
            // Verifica se a variável existe no PLC

            //   outputValue = plc.ReadBit(DataType.DataBlock, dbNumber, byteIndex, bitIndex);
            ///bool valorEntrada = (bool)plc.Read(DataType.DataBlock, 1, 0, VarType.Byte, 1, 0);
            //byte[] a = plc.ReadBytes(DataType.Output, 0, 0, 1);
            //   byte myByte = plc.ReadBytes(DataType.Output, 0, 0, 1);
            //Debug.LogWarning("Saida: "+ a[0].ToString());
            byte[] a = { 15 };
            plc.WriteBytes(DataType.Output, 0, 0, a);
            byte[] b = plc.ReadBytes(DataType.Input, 0, 0, 1);
            Debug.LogWarning("Entrada 0: " + b[0].ToString());

            //plc.Close(); // fecha a conexão com o PLC
            // Debug.LogWarning(plc.Read(DataType.Input, 0, 1, VarType.Bit, 1));
        }
        else { }

        if (true && Time.time - ultimaExecucao > intervaloDeTempo)
        // colocar aqui o código que só deve ser executado a cada intervaloDeTempo segundos
        {
            Debug.Log("Passe IF");
            plcAction();
            ultimaExecucao = Time.time;
        }
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

    public void plcAction()
    {
        //   myByte = plc.ReadBytes(DataType.Output, 0, 0, 1);
        Debug.Log(" IF O valor do byte vindo do plc e :" + myByte);

        for (int i = 7; i >= 0; i--)
        {
            // obtem o i-ésimo bit do byte
            vetorDeBits[i] = (byte)((myByte >> i) & 1);

            // imprime o bit na tela (pode ser armazenado em um array ou variável, dependendo do seu uso)
            Debug.Log("Bit " + i + ": " + vetorDeBits[i]);
        }

        if (britador1 != null)
        {
            if (vetorDeBits[0] == 1) // Primeira Britadeira
            {
                britador1.ligar();
            }
            else
                britador1.parar();
        }
    }

    public void plcWrite()
    {
        for (int i = 7; i >= 0; i--)
        {
            if (vetorDeBits[i] == 1)
            {
                myByte |= (byte)(1 << (i));
            }
        }
        // plc.WriteBytes(DataType.Output, 0, 0, myByte);

        Debug.Log("Resultado: " + myByte); 
    }
}
