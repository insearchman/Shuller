using TMPro;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI debugGUI;
    [SerializeField] private bool debugGUIEnabled = false;
    [SerializeField] private MusicButton musicButton;
    [SerializeField] private SoundButton soundButton;

    private void Start()
    {
        debugGUI.enabled = debugGUIEnabled;
        //debugGUI.text = Application.targetFrameRate.ToString();

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;

        CreatePlayerPrefs();
        LoadPlayerPrefs();
    }

    private void CreatePlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("firstGameStart"))
        {
            PlayerPrefs.SetInt("firstGameStart", 1);
            PlayerPrefs.SetFloat("Volume", 1.0f);
            PlayerPrefs.SetInt("Music", 0);
        }
    }

    private void LoadPlayerPrefs()
    {
        if (PlayerPrefs.GetFloat("Volume") == 1.0f)
        {
            soundButton.VolumeSwitch(true);
        }
        else
        {
            soundButton.VolumeSwitch(false);
        }

        if (PlayerPrefs.GetInt("Music") == 1)
        {
            musicButton.MusicSwitch(true);
        }
        else
        {
            musicButton.MusicSwitch(false);
        }
    }
}