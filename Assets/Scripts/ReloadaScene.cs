using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadaScene : MonoBehaviour
{
    public GameObject panelLoose;
    public static bool looseOk;
    void Start()
    {
        looseOk = false;
        panelLoose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(looseOk)
        {
            panelLoose.SetActive(true);
        }
    }

    public void Loose()
    {
        SceneManager.LoadScene(2);
    }
}
