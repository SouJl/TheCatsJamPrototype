using System;
using UnityEngine;

namespace Shooter.Audio
{
    internal interface IAudio
    {
        string Name { get; }
        bool IsSoundOn { get; }

        void Play();
        void Pause();
        void Stop();
        void SetVolume(float volumeValue);

        float GetVolumeValue();
    }

    internal class AudioModel : IAudio
    {
        private readonly IAudioConfig _config;
        private readonly AudioSource _source;

        public string Name { get; private set; }

        public bool IsSoundOn { get => _source.isPlaying; }

        public AudioModel(IAudioConfig config, AudioSource source)
        {
            _config
                = config ?? throw new ArgumentNullException(nameof(config));

            _source
                = source ?? throw new ArgumentNullException(nameof(source));

            Name = _config.Name;

            SetAudioData();
        }

        private void SetAudioData()
        {
            _source.volume = _config.Volume;
            _source.pitch = _config.Pitch;
            _source.loop = _config.Loop;
            _source.spatialBlend = _config.SpatialBlend;
            _source.reverbZoneMix = _config.ReverZoneMix;

            _source.clip = _config.AudioClip;
            _source.outputAudioMixerGroup = _config.AudioMixer;
        }

        public void Play() =>
            _source.Play();

        public void Pause() =>
            _source.Pause();

        public void Stop() =>
            _source.Stop();

        public void SetVolume(float volumeValue) =>
            _source.volume = volumeValue;

        public float GetVolumeValue() =>
            _source.volume;
    }
}
