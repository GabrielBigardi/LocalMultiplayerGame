using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTriggerArea : MonoBehaviour
{
    public int[] ids;

    public Sprite untriggeredSprite;
    public Sprite triggeredSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().sprite = triggeredSprite;

        StartCoroutine(DelayedButtonPress());
    }

    private IEnumerator DelayedButtonPress()
    {
        foreach (var id in ids)
        {
            GameEvents.Instance.ButtonTriggerEnter(id);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
