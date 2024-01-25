using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;

    public void AddScore(int amount)
    {
        scoreManager.AddScore(amount);
    }



}
