using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartGameButtom : MonoBehaviour, IPointerClickHandler
{
   
    public void OnPointerClick(PointerEventData eventData)
    {
        Invoke("openMainBatleScene", 1);
    }

    private void openMainBatleScene()
    {
        SceneManager.LoadScene("baseScene");
    }
}
