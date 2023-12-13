using System;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private LoseScreen _loseScreen;

    private void Awake()
    {
        ServiceLocator.MainUI = this;
    }

    public void ShowLoseScreen()
    {
        _loseScreen.gameObject.SetActive(true);    
    }
}
