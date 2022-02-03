using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour, IBumpable
{
    [SerializeField] private float _launchSpeed;

    public void OnBump(Transform bumper)
    {
        bumper.gameObject.GetComponent<PlayerEntity>().core.rgbd.velocity = (Vector3)bumper.gameObject.GetComponent<PlayerEntity>().core.rgbd.velocity + (transform.up * _launchSpeed);
    }
}
