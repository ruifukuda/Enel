using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title: MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Game");
    }
}