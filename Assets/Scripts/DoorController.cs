using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    private void Start()
    {
        GameEvents.Instance.onDoorwayTriggerEnter += DoorwayOpen;
        GameEvents.Instance.onDoorwayTriggerExit += DoorwayExit;
    }

    private void OnDisable()
    {
        GameEvents.Instance.onDoorwayTriggerEnter -= DoorwayOpen;
        GameEvents.Instance.onDoorwayTriggerExit -= DoorwayExit;
    }

    private void DoorwayOpen()
    {
        transform.DOMoveY(-3.6875f,2f).SetEase(Ease.OutBounce);
    }

    private void DoorwayExit()
    {
        transform.DOMoveY(10.5f, 1f);
    }
}
