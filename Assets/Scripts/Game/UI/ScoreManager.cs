using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    [SerializeField] Text text;

    public void AddScore(int amount)
    {
        score += amount;
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = "Score: " + score.ToString();
    }
}
