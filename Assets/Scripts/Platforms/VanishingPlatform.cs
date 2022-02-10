using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingPlatform : MonoBehaviour
{
    [SerializeField] private float _vanishSpeed = 0.008f;
    [SerializeField] private float _unvanishSpeed = 0.002f;
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;

    public Vector3 contactPoint;
    public Vector3 center;
    public Vector3 normalized;

    bool fading = false;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !fading)
        {
            var entity = collision.gameObject.GetComponent<PlayerEntity>();
            Vector3 _contactPoint = contactPoint = collision.contacts[0].point;
            Vector3 _center = center = _collider.bounds.center;
            Vector3 _distanceFromCenter = _contactPoint - _center;
            Vector3 _normalized = new Vector3(_distanceFromCenter.x / _collider.bounds.size.x, _distanceFromCenter.y / _collider.bounds.size.y).normalized;
            normalized = new Vector3(Mathf.RoundToInt(_normalized.x), Mathf.Round(_normalized.y));

            bool right = contactPoint.x > center.x;
            bool left = contactPoint.x < center.x;
            bool top = contactPoint.y > center.y;
            bool bottom = contactPoint.y < center.y;

            Debug.Log($"Right: {right}, Left: {left}, Top: {top}, Bottom: {bottom}");

            //Debug.Log($"Right: {right}, Left: {left}, Top: {top}, Bottom: {bottom}");

            if (top && entity.core.rgbd.velocity.y == 0f)
            {
                StartCoroutine(FadeTask()); 
            }
        }
    }

    public IEnumerator FadeTask()
    {
        var alpha = 1f;
        fading = true;

        while (alpha > 0f)
        {
            alpha -= _vanishSpeed;
            Color newColor = new Color(1, 1, 1, alpha);
            _spriteRenderer.color = newColor;
            yield return null;
        }

        _collider.enabled = false;

        yield return new WaitForSeconds(1f);

        while (alpha < 1f)
        {
            alpha += _unvanishSpeed;
            Color newColor = new Color(1, 1, 1, alpha);
            _spriteRenderer.color = newColor;
            yield return null;
        }

        _collider.enabled = true;
        fading = false;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(contactPoint, 0.1f);
    //    
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(center, 0.1f);
    //
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(normalized, 0.1f);
    //}
}
