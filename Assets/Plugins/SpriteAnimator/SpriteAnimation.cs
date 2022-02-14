using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu]
[Serializable]
public class SpriteAnimation : ScriptableObject
{
    public string animationName = "animation";

    public string Name { get; set; }

    public int FPS { get; set; }

    public List<SpriteAnimationFrame> Frames { get; private set; }

    public SpriteAnimationType SpriteAnimationType { get; set; }
}