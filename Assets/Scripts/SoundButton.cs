using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    private Image _soundButton;
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;

    private AudioSource _buttonClick;

    private bool _isOn = true;

    private const float maxVolume = 1.0f;
    private const float minVolume = 0.0f;

    private void Start()
    {
        _soundButton = GetComponent<Image>();
        _buttonClick = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        _isOn = !_isOn;
        _buttonClick.Play();
        VolumeSwitch(_isOn);
    }
    private void VolumeSwitch(bool state)
    {
        if (state)
        {
            AudioListener.volume = maxVolume;
            _soundButton.sprite = _soundOn;
            PlayerPrefs.SetFloat("Volume", maxVolume);
        }
        else
        {
            AudioListener.volume = minVolume;
            _soundButton.sprite = _soundOff;
            PlayerPrefs.SetFloat("Volume", minVolume);
        }
    }
}
