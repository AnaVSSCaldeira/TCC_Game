using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CaesarCipher : MonoBehaviour
{
    public static CaesarCipher instance;

    public int panelIndex;
    public Sprite[] panelsList;
    public string answer = "";

    [SerializeField] private TextMeshProUGUI txtPanel;
    private int sumNumber;
    private string plainText = "";
    private List<string> alphabetList = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    private int letterIndex;

    [SerializeField] private TextMeshProUGUI txtPuzzleCount;

    [SerializeField] private TextMeshProUGUI txtDescription;
    void Start()
    {
        instance = this;
        Setup();
    }

    private void Setup()
    {
        panelIndex = Random.Range(0, 4);
        GetComponent<SpriteRenderer>().sprite = panelsList[panelIndex];
        if (panelIndex == 0)
        {
            sumNumber = 3;
        }
        else if (panelIndex == 1)
        {
            sumNumber = 4;
        }
        else if (panelIndex == 2)
        {
            sumNumber = 5;
        }
        else if (panelIndex == 3)
        {
            sumNumber = 6;
        }

        for (int i = 0; i < 3; i++)
        {
            letterIndex = Random.Range(0, 26);
            plainText = plainText + alphabetList[letterIndex];
        }
        txtPanel.text = plainText;
        CaesarCipherAnswer();
    }
    private string CaesarCipherAnswer()
    {

        for (int i = 0; i<plainText.Length; i++)
        {
            foreach (string letter in alphabetList)
            {
                if(letter == plainText[i].ToString())
                {
                    int index = alphabetList.IndexOf(letter);

                    if ((index + sumNumber) >= alphabetList.Count)
                    {
                        int ah = sumNumber - (alphabetList.Count - index);
                        answer = answer + alphabetList[ah];
                    }
                    else
                    {
                        answer = answer + alphabetList[index + sumNumber];
                    }

                    break;
                }
            }
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
