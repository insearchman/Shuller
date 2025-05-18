using UnityEngine;

public class DeviceCardsControl : MonoBehaviour
{
    private DeviceCard[] cards;
    private const string CLEAN_MASK = "Clean";

    void Start()
    {
        cards = GetComponentsInChildren<DeviceCard>();
    }

    public void CleanCardsMask()
    {
        foreach (DeviceCard card in cards)
        {
            card.ChangeMaskLayer(CLEAN_MASK);
        }
    }
}