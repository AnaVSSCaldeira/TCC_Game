using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackMenu:MonoBehaviour
{
    [SerializeField] private Scrollbar scroll;
    private void Start()
    {
        scroll.gameObject.SetActive(false);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
