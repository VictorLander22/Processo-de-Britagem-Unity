using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cena1Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject brita1;

    [SerializeField]
    private Vector3 brita1Position = new Vector3(4f, 12f, 10.5f);

    [SerializeField]
    private GameObject brita2;

    [SerializeField]
    private Vector3 brita2Position = new Vector3(4f, 12f, 10.5f);

    [SerializeField]
    private GameObject brita3;

    [SerializeField]
    private Vector3 brita3Position = new Vector3(-0.73f, 1.53f, 3.223368f);

    [SerializeField]
    private GameObject brita4;

    [SerializeField]
    private Vector3 brita4Position = new Vector3(-0.73f, 1.53f, 3.223368f);

    [SerializeField]
    private GameObject brita5;

    [SerializeField]
    private Vector3 brita5Position = new Vector3(-0.73f, 1.53f, 3.223368f);

    [SerializeField]
    public void MenuButton(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    public IEnumerator SpawnBrita1() // spawna a brita q cai no britador
    {
        Instantiate(brita1, brita1Position, Quaternion.identity);

        yield return null;
    }

    public IEnumerator SpawnBrita2() // spawna a brita q sai do britador e vai pra esteira
    {
        for (int i = 0; i < 1; i++)
        {
            Instantiate(brita2, brita2Position, Quaternion.identity);
            yield return new WaitForSeconds(0.3f);
        }
    }

    public IEnumerator SpawnBrita3() // spawna as britas na saida primaria
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(brita3, brita3Position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator SpawnBrita4() // spawna as britas na saida primaria
    {
        for (int i = 0; i < 12; i++)
        {
            Instantiate(brita4, brita4Position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator SpawnBrita5() // spawna as britas na saida primaria
    {
        for (int i = 0; i < 35; i++)
        {
            Instantiate(brita5, brita5Position, Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
