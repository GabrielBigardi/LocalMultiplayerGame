using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Scriptable/Player Data")]
public class PlayerData : ScriptableObject
{
    public LayerMask groundLayer;
    public LayerMask waterLayer;
    public float shootDelay = 0.25f;

    [Header("Movement")]
    public float moveSpeed = 120f;
    public float airSpeed = 120f;
    public float waterSpeed = 60f;

    [Header("Jump")]
    public float jumpForce;
    public float jumpBufferTime = 0.25f;
}
