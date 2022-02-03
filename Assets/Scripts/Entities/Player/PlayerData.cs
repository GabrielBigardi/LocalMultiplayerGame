using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Scriptable/Player Data")]
public class PlayerData : ScriptableObject
{
    public LayerMask groundLayer;
    public LayerMask waterLayer;
    public float shootDelay;

    [Header("Movement")]
    public float moveSpeed;
    public float airSpeed;
    public float waterSpeed;
    public float runSpeedMultiplier;

    [Header("Jump")]
    public float jumpForce;
    public float jumpBufferTime;
}
