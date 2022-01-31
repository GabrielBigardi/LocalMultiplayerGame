using UnityEngine;
using System.Collections.Generic;
using System;

namespace SimpleSpriteAnimator
{
    public class SpriteAnimator : MonoBehaviour
    {
        [SerializeField] private List<SpriteAnimation> spriteAnimations = new List<SpriteAnimation>();
        [SerializeField] private bool playAutomatically = true;

        public SpriteAnimation DefaultAnimation => spriteAnimations.Count > 0 ? spriteAnimations[0] : null;
        public SpriteAnimation CurrentAnimation => spriteAnimationHelper.CurrentAnimation;

        public bool Playing => state == SpriteAnimationState.Playing;
        public bool Paused => state == SpriteAnimationState.Paused;
        public int CurrentFrame => spriteAnimationHelper.GetCurrentFrame();
        public bool IsLastFrame => CurrentFrame == CurrentAnimation.Frames.Count - 1;

        private SpriteRenderer spriteRenderer;
        private SpriteAnimationHelper spriteAnimationHelper;
        private SpriteAnimationState state = SpriteAnimationState.Playing;
        private SpriteAnimationFrame previousAnimationFrame;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if(spriteRenderer == null) spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            spriteAnimationHelper = new SpriteAnimationHelper();
        }

        private void Start()
        {
            if (playAutomatically)
            {
                Play(DefaultAnimation);
            }
        }

        private void LateUpdate()
        {
            if (Playing)
            {
                SpriteAnimationFrame currentFrame = spriteAnimationHelper.UpdateAnimation(Time.deltaTime);

                if (currentFrame != null && currentFrame != previousAnimationFrame)
                {
                    previousAnimationFrame = currentFrame;
                    spriteRenderer.sprite = currentFrame.Sprite;
                }
            }
        }

        public void Play()
        {
            if (CurrentAnimation == null)
            {
                spriteAnimationHelper.ChangeAnimation(DefaultAnimation);
            }

            Play(CurrentAnimation);
        }

        public void Play(string name)
        {
            Play(GetAnimationByName(name));
        }

        public void Play(SpriteAnimation animation)
        {
            state = SpriteAnimationState.Playing;
            spriteAnimationHelper.ChangeAnimation(animation);
        }
 
        private SpriteAnimation GetAnimationByName(string name)
        {
            for (int i = 0; i < spriteAnimations.Count; i++)
            {
                if (spriteAnimations[i].Name == name)
                {
                    return spriteAnimations[i];
                }
            }

            return null;
        }
    }
}
