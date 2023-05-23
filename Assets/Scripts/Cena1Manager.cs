using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cena1Manager : MonoBehaviour
{
    public GameObject brita1;

    [SerializeField]
    private Vector3 brita1Position = new Vector3(4f, 12f, 10.5f);

    public GameObject brita2;

    [SerializeField]
    private Vector3 brita2Position = new Vector3(4f, 12f, 10.5f);

    [SerializeField]
    public void MenuButton(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    public IEnumerator SpawnBrita1()
    {
        Instantiate(brita1, brita1Position, Quaternion.identity);

        yield return null;
    }

    public IEnumerator SpawnBrita2()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(brita2, brita2Position, Quaternion.identity);
            yield return null;
        }
    }
}
