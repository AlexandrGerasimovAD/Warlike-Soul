using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadingManager : MonoBehaviour
{
    public int _deley;
    // Start is called before the first frame update
    void Start()
    {
        VoidClosedLoading();
    }

    public void openLoadingPanel()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        Invoke("closedLoading", _deley);
    }
    private void VoidClosedLoading()
    {
        Invoke("closedLoading", _deley);
    }
    private void closedLoading()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
