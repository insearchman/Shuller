using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;

    private Image _soundButton;
    private AudioSource _buttonClick;

    private bool _isOn;

    private const float maxVolume = 1.0f;
    private const float minVolume = 0.0f;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);

        _soundButton = GetComponent<Image>();
        _buttonClick = GetComponent<AudioSource>();
    }

    private void OnClick()
    {
        _isOn = !_isOn;
        VolumeSwitch(_isOn);
    }
    public void VolumeSwitch(bool state)
    {
        if (state)
        {
            AudioListener.volume = maxVolume;
            _soundButton.sprite = _soundOn;
            _soundButton.SetNativeSize();
            PlayerPrefs.SetFloat("Volume", maxVolume);
            _isOn = true;
        }
        else
        {
            AudioListener.volume = minVolume;
            _soundButton.sprite = _soundOff;
            _soundButton.SetNativeSize();
            PlayerPrefs.SetFloat("Volume", minVolume);
            _isOn = false;
        }
    }
}
