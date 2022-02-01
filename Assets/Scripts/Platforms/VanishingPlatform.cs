using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingPlatform : MonoBehaviour
{
    [SerializeField] private float _vanishSpeed;
    [SerializeField] private float _unvanishSpeed;

    bool fading = false;

    private async void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !fading)
        {
            await FadeTask();
        }
    }

    public async UniTask FadeTask()
    {
        var alpha = 1f;
        fading = true;

        while (alpha > 0f)
        {
            alpha -= _vanishSpeed;
            Color newColor = new Color(1, 1, 1, alpha);
            GetComponent<SpriteRenderer>().color = newColor;
            await UniTask.Yield();
        }

        GetComponent<Collider2D>().enabled = false;

        await UniTask.Delay(1000);

        while (alpha < 1f)
        {
            alpha += _unvanishSpeed;
            Color newColor = new Color(1, 1, 1, alpha);
            GetComponent<SpriteRenderer>().color = newColor;
            await UniTask.Yield();
        }

        GetComponent<Collider2D>().enabled = true;
        fading = false;
    }
}
