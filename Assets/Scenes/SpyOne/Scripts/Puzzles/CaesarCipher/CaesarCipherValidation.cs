using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CaesarCipherValidation : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputText;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private Button submit, goBackRoom;
    [SerializeField] private GameObject confirm;

    void Start()
    {
        Setup();
    }

    private void Setup()
    {
        GetComponent<Image>().sprite = CaesarCipher.instance.panelsList[CaesarCipher.instance.panelIndex];
    }
    private void Submmit()
    {
        if (inputText.text.Length > 2)
        {
            if (CaesarCipher.instance.answer == inputText.text.ToUpper())
            {
                feedbackText.color = new Color32(49, 239, 8, 255);
                feedbackText.text = "Correto";
                submit.interactable = false;
                inputText.interactable = false;
                GameManager.gameManagerInstance.completedPuzzles.Add(true);
                confirm.SetActive(true);
            }
            else
            {
                StartCoroutine(Feedback());
            }
        }
        else
        {
            StartCoroutine(Feedback());
        }
    }

    IEnumerator Feedback()
    {
        submit.interactable = false;
        inputText.interactable = false;
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
        inputText.interactable = true;
        goBackRoom.interactable = true;

    }
}
