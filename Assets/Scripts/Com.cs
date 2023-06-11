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
    public Plc plc;

    [SerializeField]
    private string ipAddress = "192.168.0.1";

    [SerializeField]
    private short rack = 0;

    [SerializeField]
    private short slot = 1;

    public Image statusConexao;

    private bool isConnecting = false;

    public byte[] PlcReadByte = new byte[1]; // byte vindo do plc
    public byte[] PlcWriteByte = new byte[1]; // byte do unity pro plc
    public bool[] vetorDeBits = new bool[8];

    // intervalo de tempo de leitura do plc
    public float intervaloDeTempoDeLeitura = 1.0f; // tempo da leitura de dados do plc

    // intervalo de tempo de leitura do plc

    // Objetos da planta

    public Alimentador alimentador1;
    public BritadorPrimario britador1;
    public Esteira esteira1;
    public Peneira peneira1;

    // Objetos da planta

    // Start is called before the first frame update
    void Start()
    {
        // Ip adrress :  192.168.0.1
        // SubnetMask = 255.255.255.0
        plc = new Plc(CpuType.S71200, ipAddress, rack, slot);
        statusConexao = GameObject.Find("StatusConexaoObject").GetComponent<Image>();

        plcConnect(plc);

        InvokeRepeating("plcRead", intervaloDeTempoDeLeitura, intervaloDeTempoDeLeitura);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //    if (true)
        if (plc.IsConnected)
        {
            Debug.LogWarning("PLC CONECTADO");
            SetConnectionStatusColor(Color.green);
        }
        else
        {
            SetConnectionStatusColor(Color.red);
        }
    }

    /**
   *Conexao executada em thread separada pra evitar que o programa fique travado durante o processo.
   */
    public async void plcConnect(Plc plc)
    {
        StopConnection();

        if (isConnecting)
        {
            Debug.LogWarning("Tentaiva de Conexão já em andamento.");
            return;
        }
        isConnecting = true;
        try
        {
            Debug.LogWarning("Tentando conectar ao PLC...");
            await plc.OpenAsync();
            Debug.LogWarning("PLC CONECTADO");
            SetConnectionStatusColor(Color.green);
        }
        catch (Exception ex)
        {
            Debug.LogError("Erro ao conectar ao PLC: " + ex.ToString());
            SetConnectionStatusColor(Color.red);
        }
        finally
        {
            isConnecting = false;
            PlcWriteByte[0] = (plc.ReadBytes(DataType.Memory, 0, 0, 1))[0];
        }
    }

    // Metodo para o botao de reconexao, agora que temos que passar o plc como parametro.
    public void clickplcReConnect()
    {
        plcConnect(plc);
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
        StopConnection();
    }

    private void OnApplicationQuit()
    {
        StopConnection();
    }

    // mudar a cor relativo aos status de conexao
    private void SetConnectionStatusColor(Color color)
    {
        statusConexao.color = color;
    }

    public void plcRead()
    {
        if (plc.IsConnected)
        {
            PlcReadByte[0] = (plc.ReadBytes(DataType.Output, 0, 0, 1))[0]; //so o primeiro membro do vetor q esta vindo com valor.
        }
        Debug.LogWarning("O valor do PlcByte e : " + PlcReadByte[0]);

        // sao 4 equipamentos no trabalho, 4 valores vindos do plc e interagindo com a simulacao po isso 0,1,2 e 3
        for (int i = 0; i <= 3; i++)
        {
            vetorDeBits[i] = ((PlcReadByte[0] >> i) & 1) == 1; // passa os lido dos byte do plc para um vetor booleano de comando
            Debug.Log("Bit " + i + ": " + vetorDeBits[i]);
        }
        if (alimentador1 != null) // Alimentador
        {
            if (vetorDeBits[0] == true)
            {
                alimentador1.ligar();
            }
            else
                alimentador1.parar();
        }
        if (britador1 != null)
        {
            if (vetorDeBits[1] == true) // Britadeira
            {
                britador1.ligar();
            }
            else
            {
                britador1.parar();
            }
        }

        if (esteira1 != null)
        {
            if (vetorDeBits[2] == true) // Esteira
            {
                esteira1.ligar();
            }
            else
            {
                esteira1.parar();
            }
        }
        if (peneira1 != null)
        {
            if (vetorDeBits[3] == true) // Peneira
            {
                peneira1.ligar();
            }
            else
            {
                peneira1.parar();
            }
        }
    }

    public void plcWrite()
    {
        if (plc.IsConnected)
            plc.WriteBytes(DataType.Memory, 0, 0, PlcWriteByte);

        Debug.LogWarning("Resultado: " + PlcWriteByte[0]);
    }

    public void LigarProcesso()
    {
        if (PlcWriteByte[0] >= 128)
            return;

        PlcWriteByte[0] = (byte)(PlcWriteByte[0] + (2));

        if (plc.IsConnected)
            plc.WriteBytes(DataType.Memory, 0, 0, PlcWriteByte);
        PlcWriteByte[0] = (byte)(PlcWriteByte[0] - (2));

        if (plc.IsConnected)
            plc.WriteBytes(DataType.Memory, 0, 0, PlcWriteByte);
    }

    public void DesligaProcesso()
    {
        if (PlcWriteByte[0] >= 128)
            return;

        PlcWriteByte[0] = (byte)(PlcWriteByte[0] + (4));
        if (plc.IsConnected)
            plc.WriteBytes(DataType.Memory, 0, 0, PlcWriteByte);

        PlcWriteByte[0] = (byte)(PlcWriteByte[0] - (4));
        if (plc.IsConnected)
            plc.WriteBytes(DataType.Memory, 0, 0, PlcWriteByte);
    }

    public void EmergenciaProcesso()
    {
        if (PlcWriteByte[0] % 2 == 0)
            PlcWriteByte[0] = (byte)(PlcWriteByte[0] + (1));
        else
            PlcWriteByte[0] = (byte)(PlcWriteByte[0] - (1));

        if (plc.IsConnected)
            plc.WriteBytes(DataType.Memory, 0, 0, PlcWriteByte);
    }
}
