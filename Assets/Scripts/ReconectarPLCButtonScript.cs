using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReconectarPLCButtonScript : MonoBehaviour
{
   public Com com;

    private void OnMouseDown()
    {
       com.clickplcReConnect();
    }
}
