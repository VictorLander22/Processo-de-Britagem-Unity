using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cena1Manager : MonoBehaviour
{
    [SerializeField]
    private float Brita1X = -1.5f;

    [SerializeField]
    private float Brita1Y = 8f;

    [SerializeField]
    private float Brita1Z = 18.66965f;
    public GameObject brita1;

    [SerializeField]
    public void MenuButton(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    public IEnumerator SpawnBrita1()
    {
        Instantiate(brita1, new Vector3(Brita1X, Brita1Y, Brita1Z), Quaternion.identity);

        yield return null;
    }
}
