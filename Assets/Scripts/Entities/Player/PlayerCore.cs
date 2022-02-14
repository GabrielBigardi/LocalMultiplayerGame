using UnityEngine;
using TMPro;

public class PlayerCore : MonoBehaviour
{
    [Header("Components")]
    public SpriteAnimator anim;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rgbd;
    public Collider2D col;
    public PlayerInputHandler playerInputHandler;
    public PlayerHealth playerHealth;

    [Header("Outlined Text")]
    public TMP_Text[] nameTextOutlines;
    public TMP_Text nameText;

    [Header("Player")]
    public Transform model;
    public Transform shootPoint;
    public Transform groundCheckPoint;
    public Collider2D defaultCollider;
    public Collider2D waterCollider;

    public PhysicsMaterial2D noFric;
    public PhysicsMaterial2D fullFric;

    [Header("Prefabs")]
    public Transform bulletPrefab;
    public Transform jumpParticlesPrefab;

    [Header("Runtime Variables")]
    public float currentShootDelay;

    public bool jumpBuffer = false;
    public float currentJumpBufferTime;
    public bool doubleJump = false;

    public float currentInWaterTime;
    public float currentDrowningTime;

    public Vector2 extraSpeed;
}
