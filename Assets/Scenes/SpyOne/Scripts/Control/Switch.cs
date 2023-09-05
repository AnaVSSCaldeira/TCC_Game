using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour
{
    public static Switch switchInstance;
    public GameObject[] cenary;
    public int index;

    public CanvasGroup imageTransition;
    public bool fadein = false;
    public bool fadeout = false;
    [SerializeField] private float timeToFade = 1;

    [SerializeField] private BoxCollider2D caesarCipherCollider;
    [SerializeField] private BoxCollider2D geometricSymbolsCollider;
    [SerializeField] private BoxCollider2D wiresCollider;
    [SerializeField] private BoxCollider2D lockerCollider;

    public Button btnNext, btnPrevius, btnPause;
    void Start()
    {
        switchInstance = this;
        index = 0;
        cenary[index].SetActive(true);
        for (int i = 1; i < cenary.Length; i++)
        {
            cenary[i].SetActive(false);
        }
    }
    void Update()
    {
        if (fadein == true)
        {
            if (imageTransition.alpha < 1)
            {
                imageTransition.alpha += timeToFade * Time.deltaTime;

                if (imageTransition.alpha >= 1)
                {
                    fadein = false;
                }
            }
        }
        if (fadeout == true)
        {
            if (imageTransition.alpha >= 0)
            {
                imageTransition.alpha -= timeToFade * Time.deltaTime;
                if (imageTransition.alpha == 0)
                {
                    fadeout = false;
                    btnNext.interactable = true;
                    btnPrevius.interactable = true;
                    btnPause.interactable = true;

                    caesarCipherCollider.enabled = true;
                    geometricSymbolsCollider.enabled = true;
                    wiresCollider.enabled = true;
                    lockerCollider.enabled = true;
                }
            }
        }
    }
    private void ActiveImages()
    {
        for (int i = 0; i < cenary.Length; i++)
        {
            if (index == i)
            {
                cenary[index].gameObject.SetActive(true);
            }
            else
            {
                cenary[i].gameObject.SetActive(false);
            }
        }
    }

    private IEnumerator ChangeRoom(int num)
    {
        btnNext.interactable = false;
        btnPrevius.interactable = false;
        btnPause.interactable = false;
        fadein = true;

        caesarCipherCollider.enabled = false;
        geometricSymbolsCollider.enabled = false;
        wiresCollider.enabled = false;
        lockerCollider.enabled = false;

        yield return new WaitForSeconds(1);
        index += num;
        if (index == cenary.Length)
        {
            index = 0;
        }
        else if (index < 0)
        {
            index = cenary.Length - 1;
        }

        ActiveImages();

        fadeout = true;
    }
    public void Next()
    {
        StartCoroutine(ChangeRoom(1));
    }

    public void Previus()
    {
        StartCoroutine(ChangeRoom(-1));
    }
}
