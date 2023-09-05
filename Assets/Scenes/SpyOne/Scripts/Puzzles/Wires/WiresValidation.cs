using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WiresValidation : MonoBehaviour
{
    [SerializeField] private List<Button> pressedButtons;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private Button submit, goBackRoom, reset;
    [SerializeField] private GameObject confirm;

    private int count = 0;

    public void ResetButtons()
    {
        for (int i = 0; i < pressedButtons.Count; i++)
        {
            pressedButtons[i].interactable = true;
        }
        pressedButtons.RemoveAll(y => y);
    }
    public void Submmit()
    {
        if (pressedButtons.Count == Wires.instance.answer.Count)
        {
            for (int i = 0; i < pressedButtons.Count; i++)
            {
                if (pressedButtons.Contains(Wires.instance.answer[i]))
                {
                    count += 1;
                }
                else
                {
                    break;
                }
            }
            if (count == Wires.instance.answer.Count)
            {
                feedbackText.color = new Color32(49, 239, 8, 255);
                feedbackText.text = "Correto";
                submit.interactable = false;
                reset.interactable = false;
                GameManager.gameManagerInstance.completedPuzzles.Add(true);
                confirm.SetActive(true);
            }
            else
            {
                StartCoroutine(Feedback());
            }
            count = 0;
        }
        else
        {
            StartCoroutine(Feedback());
        }
    }
    public void GetButtons(Button button)
    {
        pressedButtons.Add(button);
    }

    IEnumerator Feedback()
    {
        submit.interactable = false;
        goBackRoom.interactable = false;
        reset.interactable = false;
        feedbackText.color = new Color32(238, 8, 20, 255);
        for (int i = 0; i < 2; i++)
        {
            feedbackText.text = "Incorreto";
            yield return new WaitForSeconds(0.5f);
            feedbackText.text = "";
            yield return new WaitForSeconds(0.5f);

        }
        submit.interactable = true;
        goBackRoom.interactable = true;
        reset.interactable = true;

    }
}
