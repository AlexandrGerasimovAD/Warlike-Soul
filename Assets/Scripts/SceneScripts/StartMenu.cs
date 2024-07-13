using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    
    void Start()
    {
        Invoke("OpenMenu", 1);
    }

   private void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
