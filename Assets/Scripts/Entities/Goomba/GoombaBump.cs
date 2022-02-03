using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaBump : MonoBehaviour, IBumpable
{
    public void OnBump(Transform bumper)
    {
        bumper.gameObject.GetComponent<PlayerEntity>().core.rgbd.velocity = (Vector3)bumper.gameObject.GetComponent<PlayerEntity>().core.rgbd.velocity + (transform.up * 15f);
        Destroy(transform.root.gameObject);
    }
}
