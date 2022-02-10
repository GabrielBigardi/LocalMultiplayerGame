using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;

    private void Awake()
    {
        Instance = this;
    }

    public event Action<int> onButtonTriggerEnter;
    public event Action<int> onButtonTriggerExit;

    public void ButtonTriggerEnter(int id)
    {
        onButtonTriggerEnter?.Invoke(id);
    }

    public void ButtonTriggerExit(int id)
    {
        onButtonTriggerExit?.Invoke(id);
    }
}
