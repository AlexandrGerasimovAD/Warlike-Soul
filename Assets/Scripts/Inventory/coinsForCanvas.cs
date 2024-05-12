using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coinsForCanvas : MonoBehaviour
{
    public int _coins;
    private TMP_Text _coinText;
    private void Start()
    {
        _coinText = GameObject.Find("textCoin").GetComponent<TMP_Text>();
        _coinText.text = PlayerPrefs.GetInt("mainCoinSave").ToString();
    }
}
