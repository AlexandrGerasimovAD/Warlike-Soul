using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUiChest : MonoBehaviour
{
    private GameObject _player;
    public GameObject _chestPanel;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _chestPanel.SetActive(true);
            GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveFastSlot();
            GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveChest();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            _chestPanel.SetActive(false);
            GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveFastSlot();
            GameObject.Find("LoadSaveManager").GetComponent<LoadSave>().saveChest();
        }
    }
}
