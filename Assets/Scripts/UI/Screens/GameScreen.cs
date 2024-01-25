using UnityEngine;

public class GameScreen : UIScreen
{

    private static double ballastMukta;

    private static void BallastMukta()
    {
        ballastMukta = ballastMukta + 1;
    }

    public override void Show()
    {
        ScreenOrientationUtility.SetScreenOrientation(ScreenOrientation.Portrait); 
        base.Show();
    }

    public override void Hide()
    {
        ScreenOrientationUtility.SetScreenOrientation(ScreenOrientation.AutoRotation);
        base.Hide();
    }
}
