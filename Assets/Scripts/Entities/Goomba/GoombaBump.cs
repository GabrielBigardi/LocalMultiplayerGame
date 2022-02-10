using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaBump : MonoBehaviour, IBumpable
{
    public void OnBump(Transform bumper)
    {
        var bumperEntity = bumper.gameObject.GetComponent<PlayerEntity>();
        bumperEntity.core.rgbd.velocity = (Vector3)bumperEntity.core.rgbd.velocity + (transform.up * 15f);
        Destroy(transform.root.gameObject);
    }
}
