using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;
    public List<bool> completedPuzzles = new List<bool>();
    public string timePassed = "";
    public float minute = 0f;
    public float second = 0f;

    private float timer = 0f;

    [SerializeField] private TextMeshProUGUI completedPuzzlesText;

    void Start()
    {
        Time.timeScale = 1;
        gameManagerInstance = this;
    }

    void Update()
    {
        //para tirar dps
        if (Input.GetKeyDown(KeyCode.F2))
        {
            completedPuzzles.Add(true);
            completedPuzzles.Add(true);
            completedPuzzles.Add(true);
            completedPuzzles.Add(true);
        }
        //
        UpdateTimer();
    }

    public void UpdateTimer()
    {
        timer += Time.deltaTime;
        minute = Mathf.FloorToInt(timer / 60);
        second = Mathf.FloorToInt(timer % 60);
        timePassed = string.Format("{0:00}:{1:00}", minute, second);
        completedPuzzlesText.text = (completedPuzzles.Count).ToString() + "/4";
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
