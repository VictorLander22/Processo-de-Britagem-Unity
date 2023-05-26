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

    public byte ComandoByte; // byte vindo do plc
    public byte[] vetorDeBit = new byte[1];
    public bool[] vetorDeBits = new bool[8];


    // intervalo de tempo de leitura do plc
    public float intervaloDeTempo = 1.0f; // tempo da leitura de dados do plc
 

    // intervalo de tempo de leitura do plc

    // Objetos da planta

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

        InvokeRepeating("plcRead", intervaloDeTempo, intervaloDeTempo);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (plc.IsConnected)
       // if (true)
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
        }
    }
    
    /**
   * Como tinhamos feito antes, por falta de conhecimento da funcao embutida na propia biblioteca. 
   * Ambos funcionam igualmente pelo testado
   */
    //public void plcConnect(Plc plc)
    //{
    //    // se a conexao existir ele a fecha. Evita multiplas conexoes simultaneas.
    //    StopConnection();
    //    if (isConnecting)
    //    {
    //        Debug.LogWarning("Tentaiva de Conexão já em andamento.");
    //        return;
    //    }
    //    isConnecting = true;

    //    Debug.LogWarning("Tentando conectar ao PLC...");
    //    plcThread = new Thread(() =>
    //    {
    //        try
    //        {
    //            // using (plc = new Plc(CpuType.S71200, ipAddress, rack, slot))
    //            {
    //                plc.Open();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Debug.LogError("Erro ao conectar ao PLC: " + ex.Message);
    //        }
    //        finally
    //        {
    //            isConnecting = false;
    //        }
    //    });
    //    plcThread.Start();
    //}

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
         ComandoByte = (plc.ReadBytes(DataType.Output, 0, 0, 1))[0]; //so o primeiro membro do vetor q esta vindo com valor.
        Debug.LogWarning("O valor do ComandoByte e : " + ComandoByte);
        byte[] bytes = BitConverter.GetBytes(ComandoByte);

        // sao 3 equipamentos no trabalho, 3 valores vindos do plc e interagindo com a simulacao po isso 0,1,2.
        for (int i = 0; i < 3; i++)
        {
            vetorDeBits[i] = ((bytes[0] >> i) & 1) == 1;
            Debug.Log("Bit " + i + ": " + vetorDeBits[i]);
        }
        if (britador1 != null)
        {
            if (vetorDeBits[0] == true) // Britadeira
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
            if (vetorDeBits[1] == true) // Esteira
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
            if (vetorDeBits[2] == true) // Peneira
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
        vetorDeBit[0] = 7;
        for (int i = 0; i < 3; i++)
        {
            if (vetorDeBits[i] == true)
            {
                vetorDeBit[0] |= (byte)(1 << i);
            }
        }
        plc.WriteBytes(DataType.Memory, 4, 0, vetorDeBit);

        Debug.Log("Resultado: " + ComandoByte);
    }



    public void LigarComandoByte()
    {
        vetorDeBit[0] = 7;
        //  plc.WriteBytes(DataType.Memory, 1, 0, vetorDeBit);
      //  plc.Write("DB4.DBW0", 4.0f);
    }

    public void ZerarComandoByte()
    {
        ComandoByte = 0;
    }

   
}
