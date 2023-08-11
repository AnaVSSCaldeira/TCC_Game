using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivePanel : MonoBehaviour
{
    [SerializeField] private GameObject[] panel;
    [SerializeField] private Button next, previus, closeModal;

    public static ActivePanel activePanelInstance;

    void Start()
    {
        activePanelInstance = this;
    }
    public void PanelControl()
    {
        next.gameObject.SetActive(!(next.IsActive()));
        previus.gameObject.SetActive(!(previus.IsActive()));
        closeModal.gameObject.SetActive(!(closeModal.IsActive()));

        Switch.switchInstance.cenary[Switch.switchInstance.index].SetActive(!(Switch.switchInstance.cenary[Switch.switchInstance.index].activeInHierarchy));
        panel[Switch.switchInstance.index].SetActive(!(panel[Switch.switchInstance.index].activeInHierarchy));

    }
}
