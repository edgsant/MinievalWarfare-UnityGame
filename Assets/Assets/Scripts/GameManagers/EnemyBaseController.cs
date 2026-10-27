using UnityEngine;

public class EnemyBaseController : MonoBehaviour
{
    public ScoreController scoreController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Unit>() != null)
        {
            int score = collision.GetComponent<Unit>().victoryScore;
            scoreController.addScore(score);
        }
        Destroy(collision.gameObject);
        
    }
}
