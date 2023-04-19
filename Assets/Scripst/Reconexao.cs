using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reconexao : MonoBehaviour
{

    [SerializeField]
    private Com comPlc;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("Tentando reconectar com o plc!");
        comPlc.plcConnect();
    }
}
