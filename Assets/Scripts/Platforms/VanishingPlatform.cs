﻿using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingPlatform : MonoBehaviour
{
    [SerializeField] private float _vanishSpeed;
    [SerializeField] private float _unvanishSpeed;
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;

    bool fading = false;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !fading)
        {
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 center = _collider.bounds.center;

            bool right = contactPoint.x > center.x;
            bool left = contactPoint.x < center.x;
            bool top = contactPoint.y > center.y;
            bool bottom = contactPoint.y < center.y;

            //Debug.Log($"Right: {right}, Left: {left}, Top: {top}, Bottom: {bottom}");

            if (top)
            {
                StartCoroutine(FadeTask()); 
            }
        }
    }

    public IEnumerator FadeTask()
    {
        var alpha = 1f;
        fading = true;

        while (alpha > 0f)
        {
            alpha -= _vanishSpeed;
            Color newColor = new Color(1, 1, 1, alpha);
            _spriteRenderer.color = newColor;
            yield return null;
        }

        _collider.enabled = false;

        yield return new WaitForSeconds(1f);

        while (alpha < 1f)
        {
            alpha += _unvanishSpeed;
            Color newColor = new Color(1, 1, 1, alpha);
            _spriteRenderer.color = newColor;
            yield return null;
        }

        _collider.enabled = true;
        fading = false;
    }
}
