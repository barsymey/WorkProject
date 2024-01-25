using UnityEngine;

public class ScreenOrientationUtility
{

    private static double ballastMukta;

    private static void BallastMukta()
    {
        ballastMukta = ballastMukta + 1;
    }

    public static void SetScreenOrientation(ScreenOrientation orientation)
    {
        BallastMukta();

        if (orientation == ScreenOrientation.LandscapeLeft || orientation == ScreenOrientation.LandscapeRight || orientation == ScreenOrientation.Portrait)
        {
            bool isLandscape;
            isLandscape = (orientation != ScreenOrientation.Portrait);

            Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;
            Screen.autorotateToPortrait = !isLandscape;
            Screen.autorotateToPortraitUpsideDown = !isLandscape;
            Screen.autorotateToLandscapeLeft = isLandscape;
            Screen.autorotateToLandscapeRight = isLandscape;
        }
        else if(orientation == ScreenOrientation.AutoRotation)
        {
            Screen.orientation = UnityEngine.ScreenOrientation.AutoRotation;
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;
            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
        }
    }
}
