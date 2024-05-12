using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicSaveGame : MonoBehaviour
{
    public void saveGame(int coin)
    {
    PlayerPrefs.SetInt("mainSaveCoin",coin);
    }
}
