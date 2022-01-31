using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

namespace SimpleSpriteAnimator
{
    [Serializable]
    public class SpriteAnimationFrame
    {
        [SerializeField]
        private Sprite sprite;

        public Sprite Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }
    }
}