using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameEvents.Instance.DoorwayTriggerEnter();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameEvents.Instance.DoorwayTriggerExit();
    }
}
