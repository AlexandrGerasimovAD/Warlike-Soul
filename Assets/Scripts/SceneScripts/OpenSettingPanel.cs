using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenSettingPanel : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Invoke("closedSettingPanel", 0.5f);
    }
    private void closedSettingPanel()
    {
        GameObject.Find("mainSetting").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("settingManager").GetComponent<SettingManager>().getSliderValue();
    }
}
