using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiaolugeManager : MonoBehaviour
{
    [SerializeField] private string[] dialogueSentences;
    [SerializeField] private TextMeshProUGUI sentencesText;
    [SerializeField] private int indexOfSentences;
    [SerializeField] private GameObject continueButton;
    private void Update()
    {
        if (sentencesText.text == dialogueSentences[indexOfSentences])
        {
            continueButton.SetActive(true);
        }
        if (indexOfSentences == dialogueSentences.Length - 1)
        {
            indexOfSentences++;
            if (indexOfSentences == dialogueSentences.Length)
            {
                continueButton.SetActive(true);
                //sentencesText.text = "";
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
             // Fare imleci serbest bırakılır

            StartCoroutine(DisplayDialogue());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
             
        }
    }

    IEnumerator DisplayDialogue()
    { 
        foreach (char letter in dialogueSentences[indexOfSentences].ToCharArray())
        { 
            sentencesText.text += letter; 
            yield return new WaitForSeconds(0.02f);
        }
    }
    public void NextDialogue()
    {
        if(indexOfSentences<dialogueSentences.Length-1)
        {
            continueButton.SetActive(false);
            indexOfSentences++;
            sentencesText.text = "";
            StartCoroutine(DisplayDialogue());
        }
        else
        {
            sentencesText.text="";
            continueButton.SetActive(false);
        }
    }
}
