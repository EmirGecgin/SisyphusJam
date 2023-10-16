using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerCont : MonoBehaviour
{

    public GameObject panel;
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartScene()
    {

        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Closed");
    }
    public void CreditsOpen()
    {
        panel.SetActive(true);
    }
    public void CreditsQuit()
    {
        panel.SetActive(false);
    }
}
