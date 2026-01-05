using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingView : MonoBehaviour
{

    [SerializeField] private GameObject root;
    [SerializeField] private Slider progressBar;

    public void Show()
    {
        root.SetActive(true);
    }

    public void Hide()
    {
        root.SetActive(false);
    }

    public void SetProgress(float value)
    {
        progressBar.value = value;
    }

}
