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

    public event Action onDoorwayTriggerEnter;
    public event Action onDoorwayTriggerExit;

    public void DoorwayTriggerEnter()
    {
        onDoorwayTriggerEnter?.Invoke();
    }

    public void DoorwayTriggerExit()
    {
        onDoorwayTriggerExit?.Invoke();
    }
}
