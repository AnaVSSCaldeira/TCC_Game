using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Locker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtDisplay;
    private int displayNumber;

    public int[] answer;
    public static Locker instance;

    [SerializeField] private TextMeshProUGUI txtPuzzleCount;
    void Start()
    {
        instance = this;
        Setup();
    }

    [SerializeField] private TextMeshProUGUI txtDescription;

    private void Setup()
    {
        displayNumber = Random.Range(1, 11);
        txtDisplay.text = displayNumber.ToString();
        LockerAnswer();
    }

    void Update()
    {
        answer[2] = GameManager.gameManagerInstance.completedPuzzles.Count;
    }

    private int[] LockerAnswer()
    {
        if (displayNumber >= 5)
        {
            if(displayNumber % 2 == 0)
            {
                answer[0] = displayNumber/2;
            }
            else
            {
                answer[0] = displayNumber - 1;
            }
        }
        else
        {
            if (displayNumber % 2 == 0)
            {
                answer[0] = displayNumber + 1;
            }
            else
            {
                answer[0] = displayNumber * 2;
            }
        }
        
        var soma = answer[0] + displayNumber;

        if(soma >= 10)
        {
            answer[1] = soma % 10;
        }
        else
        {
            answer[1] = soma;
        }
        
        return answer;
    }

    private void OnMouseOver()
    {
        txtDescription.gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        txtDescription.gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (Time.timeScale != 0)
        {
            txtDescription.gameObject.SetActive(false);
            ActivePanel.activePanelInstance.PanelControl();
            txtPuzzleCount.gameObject.SetActive(false);
        }
    }
}
