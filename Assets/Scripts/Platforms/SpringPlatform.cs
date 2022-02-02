using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour
{
    [SerializeField] private float _launchSpeed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var direction = transform.up;
            print(direction);
            collision.gameObject.GetComponent<PlayerEntity>().core.rgbd.velocity = (Vector3)collision.gameObject.GetComponent<PlayerEntity>().core.rgbd.velocity + (direction * _launchSpeed);
            //collision.gameObject.GetComponent<PlayerEntity>().SetVelocityY(_launchSpeed);
        }
    }
}
