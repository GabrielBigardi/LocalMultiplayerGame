﻿using UnityEngine;
using System.Collections.Generic;
using System;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] private List<SpriteAnimation> _spriteAnimations = new List<SpriteAnimation>();
    [SerializeField] private bool _playAutomatically = true;

    public SpriteAnimation DefaultAnimation => _spriteAnimations.Count > 0 ? _spriteAnimations[0] : null;
    public SpriteAnimation CurrentAnimation => _spriteAnimationHelper.CurrentAnimation;

    public bool Playing => _state == SpriteAnimationState.Playing;
    public bool Paused => _state == SpriteAnimationState.Paused;
    public int CurrentFrame => _spriteAnimationHelper.GetCurrentFrame();
    public bool IsLastFrame => CurrentFrame == CurrentAnimation.Frames.Count - 1;

    private SpriteRenderer _spriteRenderer;
    private SpriteAnimationHelper _spriteAnimationHelper;
    private SpriteAnimationState _state = SpriteAnimationState.Playing;
    private SpriteAnimationFrame _previousAnimationFrame;

    //private int _currentAnimationLoops = 0;
    //private int _previousFrame = 0;
    private bool triggerAnimationEndedEvent = false;

    public Action SpriteChanged;
    public Action<SpriteAnimation> AnimationPlayed;
    public Action<SpriteAnimation> AnimationPaused;
    public Action AnimationEnded;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        if(_spriteRenderer == null) _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        _spriteAnimationHelper = new SpriteAnimationHelper();
    }

    private void Start()
    {
        if (_playAutomatically)
        {
            Play(DefaultAnimation);
        }
    }

    private void LateUpdate()
    {
        if (Playing)
        {
            SpriteAnimationFrame currentFrame = _spriteAnimationHelper.UpdateAnimation(Time.deltaTime);

            //Change sprite every LateUpdate tick, but call sprite changed event based on frame change
            if (currentFrame != null)
            {
                //_spriteRenderer.sprite = currentFrame.Sprite;

                //ON FRAME CHANGE
                if(currentFrame != _previousAnimationFrame)
                {
                    //Check if should trigger animation ended event
                    if (triggerAnimationEndedEvent)
                    {
                        AnimationEnded?.Invoke();

                        //If animation is looping, keep changing sprites, else don't
                        if (CurrentAnimation.SpriteAnimationType != SpriteAnimationType.Looping) return;
                    }

                    //Set bool to trigger Animation Ended Event on next frame
                    if ((CurrentFrame + 1) > (CurrentAnimation.Frames.Count - 1))
                    {
                        //Debug.Log($"End of frame reached, next frame will trigger animation end event");
                        triggerAnimationEndedEvent = true;
                        //_currentAnimationLoops++;
                        //
                        //if(_currentAnimationLoops > 1)
                        //    AnimationEnded?.Invoke();
                    }

                    _previousAnimationFrame = currentFrame;

                    _spriteRenderer.sprite = currentFrame.Sprite;

                    SpriteChanged?.Invoke();
                }
            }

            //Change sprite only on frame change
            //if (currentFrame != null && currentFrame != _previousAnimationFrame)
            //{
            //    _previousAnimationFrame = currentFrame;
            //    _spriteRenderer.sprite = currentFrame.Sprite;
            //}
        }
    }

    public void Play()
    {
        if (CurrentAnimation == null)
        {
            _spriteAnimationHelper.ChangeAnimation(DefaultAnimation);
        }

        Play(CurrentAnimation);
    }

    public void Play(string name)
    {
        Play(GetAnimationByName(name));
    }

    public void Play(SpriteAnimation animation)
    {
        _state = SpriteAnimationState.Playing;
        _spriteAnimationHelper.ChangeAnimation(animation);
        AnimationPlayed?.Invoke(animation);

        //_previousFrame = 0;
        //_currentAnimationLoops = 0;
        triggerAnimationEndedEvent = false;
    }

    public void Pause()
    {
        _state = SpriteAnimationState.Paused;
        AnimationPaused?.Invoke(CurrentAnimation);
    }

    public void Resume()
    {
        _state = SpriteAnimationState.Playing;
    }

    public SpriteAnimation GetAnimationByName(string name)
    {
        for (int i = 0; i < _spriteAnimations.Count; i++)
        {
            if (_spriteAnimations[i].Name == name)
            {
                return _spriteAnimations[i];
            }
        }

        return null;
    }
}