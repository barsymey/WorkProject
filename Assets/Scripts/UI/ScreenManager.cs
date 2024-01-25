using System;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager singleton;

    [SerializeField] UIScreen loadingScreen;
    [SerializeField] UIScreen gameScreen;
    [SerializeField] WebViewScreen webViewScreen;
    private string compareSample;

    void Start()
    {
        if(!singleton)
            singleton = this;
        else Destroy(this);
    }

    public void ShowWebViewIfNotContains(string url, string sample)
    {
        compareSample = sample;
        ShowWebViewScreen(url);
        webViewScreen.GetPageContent(CompareContent);
    }

    void CompareContent(string content)
    {
        if(content.Contains(compareSample))
        {
            ShowGameScreen();
        }
    }

    public void ShowLoadingScreen()
    {
        HideAllScreens();
        loadingScreen.Show();
    }

    public void ShowGameScreen()
    {
        HideAllScreens();
        gameScreen.Show();
    }

    public void ShowWebViewScreen(string url)
    {
        HideAllScreens();
        webViewScreen.Show(url);
    }

    void HideAllScreens()
    {
        loadingScreen.Hide();
        gameScreen.Hide();
        webViewScreen.Hide();
    }
}
