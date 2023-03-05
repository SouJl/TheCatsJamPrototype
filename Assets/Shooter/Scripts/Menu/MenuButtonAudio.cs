using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shooter.Audio;

public class MenuButtonAudio : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private Sprite _offSprite;
    [SerializeField] private Image _buttonImage;

    public void Switch()
    {
        bool turnedOn = _audioManager.SwitchAudioOnOff();
        _buttonImage.sprite = turnedOn ? _onSprite : _offSprite;
    }
}
