using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerArea : MonoBehaviour
{
    public int[] ids;

    public Sprite untriggeredSprite;
    public Sprite triggeredSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().sprite = triggeredSprite;

        StartCoroutine(DelayedDoorway());
    }

    private IEnumerator DelayedDoorway()
    {
        foreach (var id in ids)
        {
            GameEvents.Instance.DoorwayTriggerEnter(id);
            yield return new WaitForSeconds(0.25f);
        }
        
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    GetComponent<SpriteRenderer>().sprite = untriggeredSprite;
    //    GameEvents.Instance.DoorwayTriggerExit(id);
    //}
}
