#define ABB
using UnityEngine;
using System;
public class AppLogic : MonoBehaviour
{
    [SerializeField] ScreenManager screenManager;
    [SerializeField] bool skipToGame;

    public static AppLogic Instance;
    string url = string.Empty;

    private static double ballastMukta;

    private static void BallastMukta()
    {
        ballastMukta = ballastMukta + 1;
    }

    async void Start()
    {
        BallastMukta();
        InitMetrica();
        
        if(!Instance)
            Instance = this;
        else
        {
            Destroy(this);
            return;
        }   

        screenManager.ShowLoadingScreen();
        
        try
        {
            url = await FirebaseLinkGetter.GetLink();
        }
        catch(Exception e)
        {
            Debug.LogError(e.StackTrace);
            screenManager.ShowGameScreen();
            return;
        }
        
        screenManager.ShowWebViewIfNotContains(url, "Privacy Policy");
            
    }

    public void ShowWebView()
    {
        
        if(url == string.Empty)
        {
            ShowGameScreen();
            return;
        }
        else
        {
            screenManager.ShowWebViewScreen(url);
        }
    }

    public void ShowGameScreen()
    {
        screenManager.ShowGameScreen();
    }

    private void InitMetrica()
    {
#if ABB
        Debug.Log("Abb");
#else
        Debug.Log("Apk");
#endif
    }
}
