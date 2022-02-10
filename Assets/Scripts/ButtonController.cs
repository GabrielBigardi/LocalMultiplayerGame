using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonController : MonoBehaviour
{
    public int id;

    private void Start()
    {
        GameEvents.Instance.onButtonTriggerEnter += ButtonPress;
        GameEvents.Instance.onButtonTriggerExit += ButtonRelease;
    }

    private void OnDestroy()
    {
        GameEvents.Instance.onButtonTriggerEnter -= ButtonPress;
        GameEvents.Instance.onButtonTriggerExit -= ButtonRelease;
    }

    private void ButtonPress(int id)
    {
        if(id == this.id)
        {
            transform.DOMoveY(-4.5f, 0.25f).SetEase(Ease.OutSine);
        }
    }

    private void ButtonRelease(int id)
    {
        if (id == this.id)
        {
            transform.DOMoveY(10.5f, 0.25f).SetEase(Ease.OutSine);
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
