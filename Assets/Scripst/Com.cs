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
    Plc plc;
    
    public Text contato;
    public Text bobina;

    public Button inputToggle;
    public Button stopButton;

    private bool estado;

    // Start is called before the first frame update
    void Start()
    {

        // Ip adrress :  192.168.0.1
        // SubnetMask = 255.255.255.0
        plc = new Plc(CpuType.S71200, "192.168.0.1", 0, 1);
        plc.Open();
        
        inputToggle.onClick.AddListener(ToggleInput);
        stopButton.onClick.AddListener(StopConnection);
    }

    // Update is called once per frame
    void Update()
    {
      //  try
      // {
        //DBX e uma boleana
        //DBW e para real
            bool Bool2 = (bool)plc.Read("DB1.DBX0.1");
            bobina.text = Bool2.ToString();

            if (plc.IsConnected)
            {
                plc.Write("DB1.DBX0.0", estado);
                bool Bool1 = (bool)plc.Read("DB1.DBX0.0");
                contato.text = Bool1.ToString();
                estado = Bool1;
            }
            //o cath do PLC exception esta dando problema
     //   }
        // catch (PLCException e)
        // {
        //     Debug.LogError(e.Message);
        // }
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
