using UnityEngine;
using UnityEngine.UI;

public class DeviceCard : MonoBehaviour
{
    [SerializeField] private AnimatorControl _animator;

    private const string SELECTED_MASK = "Selected";

    private Button _button;
    private SpriteMask _mask;

    void Start()
    {
        _mask = GetComponent<SpriteMask>();

        _button = GetComponentInChildren<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        ChangeMaskLayer(SELECTED_MASK);

        _animator.PlayNextStep();
    }

    public void ChangeMaskLayer(string layerName)
    {
        _mask.frontSortingLayerID = SortingLayer.NameToID(layerName);
    }
}