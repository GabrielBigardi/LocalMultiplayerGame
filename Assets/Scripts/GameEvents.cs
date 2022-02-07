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

    public event Action<int> onDoorwayTriggerEnter;
    public event Action<int> onDoorwayTriggerExit;

    public void DoorwayTriggerEnter(int id)
    {
        onDoorwayTriggerEnter?.Invoke(id);
    }

    public void DoorwayTriggerExit(int id)
    {
        onDoorwayTriggerExit?.Invoke(id);
    }
}
