using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    [SerializeField] private Sprite _musicOn;
    [SerializeField] private Sprite _musicOff;

    private Image _musicButton;
    private AudioSource _gameMusic;

    private bool _isOn;

    private void Awake()
    {
        _musicButton = GetComponent<Image>();
        _gameMusic = GetComponent<AudioSource>();
    }

    public void OnClick()
    {
        _isOn = !_isOn;
        MusicSwitch(_isOn);
    }

    public void MusicSwitch(bool state)
    {
        if (state)
        {
            _gameMusic.Play();
            _musicButton.sprite = _musicOn;
            _musicButton.SetNativeSize();
            PlayerPrefs.SetInt("Music", 1);
            _isOn = true;
        }
        else
        {
            _gameMusic.Stop();
            _musicButton.sprite = _musicOff;
            _musicButton.SetNativeSize();
            PlayerPrefs.SetInt("Music", 0);
            _isOn = false;
        }
    }
}
