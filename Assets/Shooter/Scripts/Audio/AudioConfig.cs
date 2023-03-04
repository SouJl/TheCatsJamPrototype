using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Shooter.Audio
{
    internal interface IAudioConfig
    {
        string Name { get; }

        float Volume { get; }

        float Pitch { get; }

        bool Loop { get; }

        float SpatialBlend { get; }

        float ReverZoneMix { get; }

        AudioClip AudioClip { get; }

        AudioMixerGroup AudioMixer { get; }
    }

    [CreateAssetMenu(fileName = nameof(AudioConfig), menuName = "Configs/Audio/" + nameof(AudioConfig))]
    internal class AudioConfig : ScriptableObject, IAudioConfig
    {
        [field: SerializeField] public string Name { get; private set; }

        [field: Range(0f, 1f)]
        [field: SerializeField] public float Volume { get; private set; }

        [field: Range(0.5f, 2f)]
        [field: SerializeField] public float Pitch { get; private set; } = 1f;

        [field: SerializeField] public bool Loop { get; private set; } = true;

        [field: Range(0f, 1f)]
        [field: SerializeField] public float SpatialBlend { get; private set; } = 0f;

        [field: Range(0f, 1.1f)]
        [field: SerializeField] public float ReverZoneMix { get; private set; } = 1f;

        [field: SerializeField] public AudioClip AudioClip { get; private set; }

        [field: SerializeField] public AudioMixerGroup AudioMixer { get; private set; }
    }
}
