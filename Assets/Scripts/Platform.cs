using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerInputHandler>().mov.y == -1f)
            {
                Collider2D ignoredCollider = collision.gameObject.GetComponentInChildren<Collider2D>();
                Physics2D.IgnoreCollision(ignoredCollider, GetComponent<Collider2D>());
                StartCoroutine(ResetColisionForCollider_CR(ignoredCollider));
            }
        }
    }

    public IEnumerator ResetColisionForCollider_CR(Collider2D collision)
    {
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>(), false);
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Physics2D.IgnoreCollision(collision.gameObject.GetComponentInChildren<Collider2D>(), GetComponent<Collider2D>(), false);
    //    }
    //}
}
