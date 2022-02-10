using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Audio Events/Simple(empty)")]
public class SimpleAudioEvent : AudioEvent
{
#if UNITY_EDITOR
    private void Reset()
    {
        List<AudioClip> clipsToAdd = new List<AudioClip>();
        foreach (var selectedObjected in Selection.objects)
        {
            if(selectedObjected is AudioClip selectedAudioClip)
            {
                clipsToAdd.Add(selectedAudioClip);
            }
        }
        clips = clipsToAdd;
    }
#endif

    public List<AudioClip> clips;

    public RangedFloat volume;

    [MinMaxRange(0, 2)]
    public RangedFloat pitch;

    public SimpleAudioEvent()
    {
        volume = new RangedFloat(1f,1f);
        pitch = new RangedFloat(1f, 1f);
    }
    
    public override void Play(AudioSource source)
    {
        if (clips.Count == 0) return;

        source.loop = false;
        source.clip = clips[Random.Range(0, clips.Count)];
        source.volume = Random.Range(volume.minValue, volume.maxValue);
        source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
        source.Play();
    }

    public override void PlayLooping(AudioSource source)
    {
        if (clips.Count == 0) return;

        source.loop = true;
        source.clip = clips[Random.Range(0, clips.Count)];
        source.volume = Random.Range(volume.minValue, volume.maxValue);
        source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
        source.Play();
    }

    public override void PlayOneShot(AudioSource source)
    {
        source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
        source.PlayOneShot(clips[Random.Range(0, clips.Count)], Random.Range(volume.minValue, volume.maxValue));
    }
}
