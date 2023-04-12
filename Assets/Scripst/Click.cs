using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    [SerializeField]
    private string nomeCena;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    void OnMouseDown()
    {
        Debug.Log("Clique detectado!");
        FindObjectOfType<AudioManager>().Play("Britador");

        SceneManager.LoadScene(nomeCena);
    }
}
