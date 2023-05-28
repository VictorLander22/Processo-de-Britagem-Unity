using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruiraBritasButton : MonoBehaviour
{
    [SerializeField]
    private DestroyPersonalClass dest1;

    private void OnMouseDown()
    {
        dest1.DestroyAllBritas();
    }
}
