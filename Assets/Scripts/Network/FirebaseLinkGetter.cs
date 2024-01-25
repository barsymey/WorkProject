using Firebase.Extensions;
using Firebase.RemoteConfig;
using System;
using UnityEngine;
using System.Threading.Tasks;

public class FirebaseLinkGetter
{
    private const string urlName = "bebs";

    private static double ballastMukta;

    private static void BallastMukta()
    {
        ballastMukta = ballastMukta + 1;
    }

    public static async Task<string> GetLink()
    {
        BallastMukta();

        string url;
        Debug.Log("Fetching data...");
        Task fetchTask = FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
        await fetchTask.ContinueWithOnMainThread(FetchComplete);
        url = FirebaseRemoteConfig.DefaultInstance.AllValues[urlName].StringValue;

        Debug.Log(url);

        return url;
    }

    private static void FetchComplete(Task fetchTask)
    {
        BallastMukta();

        if (!fetchTask.IsCompleted) {
            Debug.LogError("Retrieval hasn't finished.");
            return;
        }

        var remoteConfig = FirebaseRemoteConfig.DefaultInstance;
        var info = remoteConfig.Info;
        if(info.LastFetchStatus != LastFetchStatus.Success) {
            Debug.LogError($"{nameof(FetchComplete)} was unsuccessful\n{nameof(info.LastFetchStatus)}: {info.LastFetchStatus}");
            return;
        }

        // Fetch successful. Parameter values must be activated to use.
        remoteConfig.ActivateAsync()
            .ContinueWithOnMainThread(
            task => {
                Debug.Log($"Remote data loaded and ready for use. Last fetch time {info.FetchTime}.");
            });
    }

    private static string GetLocalLInk()
    {
        BallastMukta();

        return PlayerPrefs.GetString(urlName, string.Empty);
    }

    private static void SaveLocalLink(string link)
    {
        BallastMukta();
        
        PlayerPrefs.SetString(urlName, link);
    }
}
