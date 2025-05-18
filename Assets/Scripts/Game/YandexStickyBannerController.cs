using System;
using UnityEngine;
using YandexMobileAds;
using YandexMobileAds.Base;

public class YandexStickyBannerController : MonoBehaviour
{
    private Banner banner;

    private void Start()
    {
        RequestStickyBanner();
    }
    private int GetScreenWidthDp()
    {
        int screenWidth = (int)Screen.safeArea.width;
        return ScreenUtils.ConvertPixelsToDp(screenWidth);
    }

    private void RequestStickyBanner()
    {
        MobileAds.SetAgeRestrictedUser(true);

        string adUnitId = "demo-banner-yandex";
        BannerAdSize bannerMaxSize = BannerAdSize.StickySize(GetScreenWidthDp());
        banner = new Banner(adUnitId, bannerMaxSize, AdPosition.BottomCenter);

        AdRequest request = new AdRequest.Builder().Build();
        banner.LoadAd(request);

        // Вызывается, когда реклама с вознаграждением была загружена
        banner.OnAdLoaded += HandleAdLoaded;

        // Вызывается, если во время загрузки произошла ошибка
        banner.OnAdFailedToLoad += HandleAdFailedToLoad;

        // Вызывается, когда приложение становится неактивным, так как пользователь кликнул на рекламу и сейчас перейдёт в другое приложение
        banner.OnLeftApplication += HandleLeftApplication;

        // Вызывается, когда пользователь возвращается в приложение после клика
        banner.OnReturnedToApplication += HandleReturnedToApplication;

        // Вызывается, когда пользователь кликнул на рекламу
        banner.OnAdClicked += HandleAdClicked;

        // Вызывается, когда зарегистрирован показ
        banner.OnImpression += HandleImpression;
    }
    private void HandleAdLoaded(object sender, EventArgs e)
    {
        Debug.Log(message: "AdLoaded event received");
        banner.Show();
    }
    private void HandleAdFailedToLoad(object sender, AdFailureEventArgs e)
    {
        Debug.Log(message: $"AdFailedToLoad event received with message: {e.Message}");
    }
    private void HandleLeftApplication(object sender, EventArgs e)
    {
        Debug.Log(message: "LeftApplication event received");
    }
    private void HandleReturnedToApplication(object sender, EventArgs e)
    {
        Debug.Log(message: "eturnedToApplication event received");
    }
    private void HandleAdClicked(object sender, EventArgs e)
    {
        Debug.Log(message: "AdClicked event received");
    }
    private void HandleImpression(object sender, ImpressionData impressionData)
    {
        var data = impressionData == null ? "null" : impressionData.rawData;
        Debug.Log(message: $"HandleImpression event received with data: {data}");
    }
}
