using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Wires : MonoBehaviour
{
    public static Wires instance;
    public List<Button> answer;
    [SerializeField] private Image wireImage;
    [SerializeField] private Sprite[] wireImagesThree;
    [SerializeField] private Sprite[] wireImagesFour;
    [SerializeField] private Sprite[] wireImagesFive;
    [SerializeField] private int wireNumber;
    [SerializeField] private int wireColors;
    [SerializeField] private Button btn1, btn2, btn3, btn4, btn5;

    [SerializeField] private TextMeshProUGUI txtPuzzleCount;

    [SerializeField] private TextMeshProUGUI txtDescription;

    void Start()
    {
        instance = this;
        Setup();
    }

    void Update()
    {
        
    }

    private void Setup()
    {
        wireNumber = Random.Range(1, 4);
        Random.State state = Random.state;
        wireColors = Random.Range(0, 3);

        if (wireNumber == 1)
        {
            wireImage.sprite = wireImagesThree[wireColors];
        }
        else if(wireNumber == 2)
        {
            wireImage.sprite = wireImagesFour[wireColors];
        }
        else if(wireNumber == 3)
        {
            wireImage.sprite = wireImagesFive[wireColors];
        }

        WiresAnswer();
    }
    private List<Button> WiresAnswer()
    {
        if (wireNumber == 1)
        {
            if (wireColors == 0)
            {
                answer.Add(btn1);
                answer.Add(btn2);
                answer.Add(btn3);
            }
            else if (wireColors == 1)
            {
                answer.Add(btn5);
            }
            else if (wireColors == 2)
            {
                answer.Add(btn3);
                answer.Add(btn4);
            }
        }
        else if (wireNumber == 2)
        {
            if (wireColors == 0)
            {
                answer.Add(btn3);
            }
            else if (wireColors == 1)
            {
                answer.Add(btn1);
                answer.Add(btn2);
                answer.Add(btn3);
                answer.Add(btn4);
                answer.Add(btn5);
            }
            else if (wireColors == 2)
            {
                answer.Add(btn1);
            }
        }
        else if (wireNumber == 3)
        {
            if (wireColors == 0)
            {
                answer.Add(btn1);
                answer.Add(btn3);
                answer.Add(btn4);
                answer.Add(btn5);
            }
            else if (wireColors == 1)
            {
                answer.Add(btn2);
                answer.Add(btn5);
            }
            else if (wireColors == 2)
            {
                answer.Add(btn2);
                answer.Add(btn3);
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
        if(Time.timeScale != 0)
        {
            txtDescription.gameObject.SetActive(false);
            ActivePanel.activePanelInstance.PanelControl();
            txtPuzzleCount.gameObject.SetActive(false);
        }
    }
}
