using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shooter.Audio
{
    internal class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;

        [SerializeField] private List<AudioConfig> _audioConfigs;
        [SerializeField] private AudioSource _audioSource;
        bool _isTurnedOff;

        private List<IAudio> _audios;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            InitAudio();

            DontDestroyOnLoad(gameObject);
        }

        private void InitAudio()
        {
            _audios = new List<IAudio>();

            foreach (var audioCfg in _audioConfigs)
            {
                var audio = CreateAudio(audioCfg, _audioSource);
                _audios.Add(audio);
            }
        }

        private IAudio CreateAudio(IAudioConfig config, AudioSource source) =>
            new AudioModel(config, source);


        public void Play(string name)
        {
            if (_isTurnedOff)
                return;

            var audio = _audios.Find(a => a.Name == name);
            if (audio == null) return;
            audio.Play();
        }

        public void Pause(string name)
        {
            if (_isTurnedOff)
                return;

            var audio = _audios.Find(a => a.Name == name);
            if (audio == null) return;
            audio.Pause();
        }

        public void Stop(string name)
        {
            if (_isTurnedOff)
                return;

            var audio = _audios.Find(a => a.Name == name);
            if (audio == null) return;
            audio.Stop();
        }

        public void SetVolume(string name, float volume)
        {
            if (_isTurnedOff)
                return;

            var audio = _audios.Find(a => a.Name == name);
            if (audio == null) return;
            audio.SetVolume(volume);
        }

        public float GetVolume(string name)
        {
            var audio = _audios.Find(a => a.Name == name);
            if (audio == null) return -1;
            return audio.GetVolumeValue();
        }

        public bool IsSoundOn(string name)
        {
            if (_isTurnedOff)
                return false;

            var audio = _audios.Find(s => s.Name == name);
            if (audio == null) return false;
            return audio.IsSoundOn;
        }

        public void TurnOffAudio()
        {
            foreach (IAudio audio in _audios)
                audio.Pause();

            _isTurnedOff = true;

        }

        public void TurnOnAudio()
        {
            foreach (IAudio audio in _audios)
                audio.Play();

            _isTurnedOff = false;
        }
    }
}
