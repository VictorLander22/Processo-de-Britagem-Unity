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

    public Plc plc;
    private bool isConnecting = false;

    public Image statusConexao;

    private Thread plcThread;

    // intervalo de tempo de leitura do plc
    public float intervaloDeTempo = 3.0f; // tempo da leitura de dados do plc
    private float ultimaExecucao = 0.0f;

    // intervalo de tempo de leitura do plc
    public byte plcByte; // byte vindo do plc
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
        //   if (plc.IsConnected)
        if (true)
        {
            Debug.LogWarning("PLC CONECTADO");
            SetConnectionStatusColor(Color.green);

            if (Time.time - ultimaExecucao > intervaloDeTempo)
            // colocar aqui o código que só deve ser executado a cada intervaloDeTempo segundos
            {
                Debug.Log("Passe IF");
                plcRead();
                ultimaExecucao = Time.time;
            }
        }
        else
        {
            SetConnectionStatusColor(Color.red);
        }
    }

    /**
    *Conexao executada em thread separada pra evitar que o programa fique travado durante o processo.
    */
    public void plcConnect(Plc plc)
    {
        // se a conexao existir ele a fecha. Evita multiplas conexoes simultaneas.
        StopConnection();

        if (isConnecting)
        {
            Debug.LogWarning("Tentaiva de Conexão já em andamento.");
            return;
        }
        isConnecting = true;

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
            finally
            {
                isConnecting = false;
            }
        });
        plcThread.Start();
    }

    // Metodo para o botao de reconexao, agora que temos que passar o plc como parametro. N encontrei maneira mais simples de se fazer
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

    public void plcRead()
    {
        // plcByte = (plc.ReadBytes(DataType.Output, 0, 0, 1))[0]; //so o primeiro membro do vetor q esta vindo com valor.
        Debug.LogWarning("O valor do plcByte e : " + plcByte);
        for (int i = 7; i >= 0; i--)
        {
            // obtem o i-ésimo bit do byte
            vetorDeBits[i] = (byte)((plcByte >> i) & 1);

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
            {
                britador1.parar();
            }
        }

        if (true)
        {
            if (vetorDeBits[1] == 1) // Primeira Britadeira
            {
                Debug.Log("Ligar Britadeira 2");
            }
            else
            {
                Debug.Log("Desligar Britadeira 2");
            }
        }
        if (true)
        {
            if (vetorDeBits[2] == 1) // Primeira Britadeira
            {
                Debug.Log("Ligar Britadeira 3");
            }
            else
            {
                Debug.Log("Desligar Britadeira 3");
            }
        }
        if (true)
        {
            if (vetorDeBits[3] == 1) // Primeira Britadeira
            {
                Debug.Log("Ligar Britadeira 4");
            }
            else
            {
                Debug.Log("Desligar Britadeira 4");
            }
        }

        if (true)
        {
            if (vetorDeBits[4] == 1) // Primeira Britadeira
            {
                Debug.Log("Ligar Britadeira 5");
            }
            else
            {
                Debug.Log("Desligar Britadeira 5");
            }
        }
        if (true)
        {
            if (vetorDeBits[5] == 1) // Primeira Britadeira
            {
                Debug.Log("Ligar Britadeira 6");
            }
            else
            {
                Debug.Log("Desligar Britadeira 6");
            }
        }
        if (true)
        {
            if (vetorDeBits[6] == 1) // Primeira Britadeira
            {
                Debug.Log("Ligar Britadeira 7");
            }
            else
            {
                Debug.Log("Desligar Britadeira 7");
            }
        }
        if (true)
        {
            if (vetorDeBits[7] == 1) // Primeira Britadeira
            {
                Debug.Log("Ligar Britadeira 8");
            }
            else
            {
                Debug.Log("Desligar Britadeira 8");
            }
        }
    }

    public void plcWrite()
    {
        for (int i = 7; i >= 0; i--)
        {
            if (vetorDeBits[i] == 1)
            {
                plcByte |= (byte)(1 << (i));
            }
        }
        // plc.WriteBytes(DataType.Output, 0, 0, plcByte);

        Debug.Log("Resultado: " + plcByte);
    }
}