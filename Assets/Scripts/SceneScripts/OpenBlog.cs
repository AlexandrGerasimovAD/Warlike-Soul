using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OpenBlog : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Invoke("openUrl", 1);
    }

    private void openUrl()
    {
        Application.OpenURL("https://t.me/GerasGames");
    }


}
