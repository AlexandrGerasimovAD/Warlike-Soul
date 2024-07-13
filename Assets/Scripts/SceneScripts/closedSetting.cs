using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class closedSetting : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Invoke("closedSettingPanel", 0.5f);
    }
    private void closedSettingPanel()
    {
        GameObject.Find("settingManager").GetComponent<SettingManager>().setSliderValue();
        GameObject.Find("mainSetting").transform.GetChild(0).gameObject.SetActive(false);       
    }
}
