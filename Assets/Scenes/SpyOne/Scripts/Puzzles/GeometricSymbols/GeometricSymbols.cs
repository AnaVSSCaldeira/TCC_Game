using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeometricSymbols : MonoBehaviour
{
    public static GeometricSymbols instance;

    [SerializeField] private Sprite[] buttonImages;
    private List<int> notPossibleValues = new List<int>();
    private int imageIndex;

    public Button[] button;
    public List<Sprite> answer = new List<Sprite>();

    [SerializeField] private TextMeshProUGUI txtPuzzleCount;
    void Start()
    {
        instance = this;
        Setup();
    }

    [SerializeField] private TextMeshProUGUI txtDescription;

    private void Setup()
    {
        for(int i = 0; i<button.Length; i++)
        {
            imageIndex = Random.Range(0, buttonImages.Length);
            if (i > 0)
            {
                while (notPossibleValues.Contains(imageIndex))
                {
                    imageIndex = Random.Range(0, buttonImages.Length);
                }
            }
            button[i].image.sprite = buttonImages[imageIndex];
            notPossibleValues.Add(imageIndex);
        }

            GeometricSymbolsAnswer();
    }

    private List<Sprite> GeometricSymbolsAnswer()
    {
        notPossibleValues.Sort();
        for (int i = 0; i < notPossibleValues.Count; i++)
        {
            answer.Add(buttonImages[notPossibleValues[i]]);
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
