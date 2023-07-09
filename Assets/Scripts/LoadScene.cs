using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettings ()
    {
        gameObject.SetActive(true);
    }

    public void CloseSettings ()
    {
        gameObject.SetActive(false);
    }
}
