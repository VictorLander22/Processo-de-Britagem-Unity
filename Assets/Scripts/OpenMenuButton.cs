using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuButton : MonoBehaviour
{
    [SerializeField]
    private Cena1Manager cena1;

    private void OnMouseDown()
    {
        cena1.MenuButton("Menu");
    }
}
