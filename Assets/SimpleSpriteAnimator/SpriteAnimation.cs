using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace SimpleSpriteAnimator
{
    [Serializable]
    [CreateAssetMenu]
    public class SpriteAnimation : ScriptableObject
    {
        public string animationName = "animation";

        public string Name { get; set; }

        public int FPS { get; set; }

        public List<SpriteAnimationFrame> Frames { get; private set; }

        public SpriteAnimationType SpriteAnimationType { get; set; }
    }
}
