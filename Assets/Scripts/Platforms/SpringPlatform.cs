using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour, IBumpable
{
    [SerializeField] private float _launchSpeed = 15f;

    public void OnBump(Transform bumper)
    {
        var bumperEntity = bumper.gameObject.GetComponent<PlayerEntity>();
        bumperEntity.core.rgbd.velocity = (Vector3)bumperEntity.core.rgbd.velocity + (transform.up * _launchSpeed);
    }
}
