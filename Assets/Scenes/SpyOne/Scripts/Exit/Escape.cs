using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Escape : MonoBehaviour
{
    [SerializeField] private Image victoryScreen;
    [SerializeField] private TextMeshProUGUI victoryText;
    [SerializeField] private TextMeshProUGUI doorText;
    [SerializeField] private BoxCollider2D door;

    void Start()
    {
    }

    void Update()
    {
        //print(GameManager.gameManagerInstance.completedPuzzles[0]);
        //print(GameManager.gameManagerInstance.completedPuzzles[1]);
        //print(GameManager.gameManagerInstance.completedPuzzles[2]);
        //print("--");
    }
    private void OnMouseDown()
    {
        ConfirmExit();
    }

    private void ConfirmExit()
    {
        if (Time.timeScale != 0)
        {
            if (GameManager.gameManagerInstance.completedPuzzles.Count == 4)
            {
                victoryText.text = "Parabéns! Você escapou da sala!\nConcluiu em " + GameManager.gameManagerInstance.timePassed;
                    victoryScreen.gameObject.SetActive(true);
            }
            else
            {
                StartCoroutine(Feedback());
            }
        }

    }

    IEnumerator Feedback()
    {
        door.enabled = false;
        doorText.color = new Color32(238, 8, 20, 255);
        for (int i = 0; i < 1; i++)
        {
            doorText.text = "Trancado";
            yield return new WaitForSeconds(1f);
            doorText.text = "";

        }
        door.enabled = true;
    }


}
