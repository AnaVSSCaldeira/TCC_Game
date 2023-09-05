using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LockerValidation : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputTextOne;
    [SerializeField] private TMP_InputField inputTextTwo;
    [SerializeField] private TMP_InputField inputTextThree;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private Button submit, goBackRoom;
    [SerializeField] private GameObject confirm;

    public void Submmit()
    {
        if(inputTextOne.text == (Locker.instance.answer[0]).ToString() && inputTextTwo.text == (Locker.instance.answer[1]).ToString() && inputTextThree.text == (Locker.instance.answer[2]).ToString())
        {
            feedbackText.color = new Color32(49, 239, 8, 255);
            feedbackText.text = "Correto";
            submit.interactable = false;
            inputTextOne.interactable = false;
            inputTextTwo.interactable = false;
            inputTextThree.interactable = false;
            GameManager.gameManagerInstance.completedPuzzles.Add(true);
            confirm.SetActive(true);
        }
        else
        {
            StartCoroutine(Feedback());
        }


    }

    IEnumerator Feedback()
    {
        submit.interactable = false;
        inputTextOne.interactable = false;
        inputTextTwo.interactable = false;
        inputTextThree.interactable = false;
        goBackRoom.interactable = false;
        feedbackText.color = new Color32(238, 8, 20, 255);
        for (int i = 0; i < 2; i++)
        {
            feedbackText.text = "Incorreto";
            yield return new WaitForSeconds(0.5f);
            feedbackText.text = "";
            yield return new WaitForSeconds(0.5f);

        }
        submit.interactable = true;
        inputTextOne.interactable = true;
        inputTextTwo.interactable = true;
        inputTextThree.interactable = true;
        goBackRoom.interactable = true;

    }
}
