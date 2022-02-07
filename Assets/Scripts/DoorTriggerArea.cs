using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerArea : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameEvents.Instance.DoorwayTriggerEnter(id);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameEvents.Instance.DoorwayTriggerExit(id);
    }
}
