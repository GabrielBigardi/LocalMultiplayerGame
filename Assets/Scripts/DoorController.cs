using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    public int id;

    private void Start()
    {
        GameEvents.Instance.onDoorwayTriggerEnter += DoorwayOpen;
        GameEvents.Instance.onDoorwayTriggerExit += DoorwayExit;
    }

    private void OnDestroy()
    {
        GameEvents.Instance.onDoorwayTriggerEnter -= DoorwayOpen;
        GameEvents.Instance.onDoorwayTriggerExit -= DoorwayExit;
    }

    private void DoorwayOpen(int id)
    {
        if(id == this.id)
        {
            transform.DOMoveY(-4.5f, 0.5f).SetEase(Ease.OutSine);
        }
    }

    private void DoorwayExit(int id)
    {
        if (id == this.id)
        {
            transform.DOMoveY(10.5f, 0.5f).SetEase(Ease.OutSine);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }
}
