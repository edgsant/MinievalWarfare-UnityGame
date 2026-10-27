using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public int score = 100;
    private int maxScore = 200;
    private int minScore = 0;
    public GameObject endGameMenu;
    public TextMeshProUGUI gameOutcomeText;

    [SerializeField]
    private RectTransform barRect;

    [SerializeField]
    private RectMask2D barMask;

    [SerializeField]
    private TMP_Text scoreText;

    public AudioClip scoreAudioClip;
    public AudioClip victoryClip;
    public AudioClip defeatClip;



    private float maxRightMask;
    private float initialRightMask;


    void Start()
    {
        maxRightMask = barRect.rect.width - barMask.padding.x - barMask.padding.z;
        scoreText.SetText($"{score}/{maxScore}");
        initialRightMask = barMask.padding.z;
        SetValue(score);
    }

    public void SetValue(int newValue)
    {
        var targetWidth = newValue * maxRightMask / maxScore;
        var newRightMask = maxRightMask + initialRightMask - targetWidth;
        var padding = barMask.padding;
        padding.z = newRightMask;
        barMask.padding = padding;
        scoreText.SetText($"{score}/{maxScore}");

        if (score <= 0)
        {
            gameEnded(false);
        }

        if (score >= 200)
        {
            gameEnded(true);
        }
    }

    public void addScore(int addedScore)
    {
        score += addedScore;
        SetValue(score);
        AudioManager.Instance.PlaySFX(scoreAudioClip,1f);
    }

    public void gameEnded(bool isVictory)
    {
        Time.timeScale = 0f;
        endGameMenu.SetActive(true);
        gameOutcomeText.enableVertexGradient = true;
        if (isVictory)
        {
            gameOutcomeText.text = "VICTORIA";
            AudioManager.Instance.PlaySFX(victoryClip, 1f);
            gameOutcomeText.color = new Color32(48, 255, 0, 255);
            Color colorGreen = new Color32(46, 226, 25, 255);
            Color colorBlack = Color.black;
            gameOutcomeText.colorGradient = new VertexGradient(
                colorGreen,
                colorBlack,
                colorGreen,
                colorBlack);
        }
        else
        {
            gameOutcomeText.text = "DERROTA";
            AudioManager.Instance.PlaySFX(defeatClip, 1f);
            gameOutcomeText.color = new Color32(255, 0, 0, 255);
            Color colorRed = new Color32(226, 47, 25, 255);
            Color colorBlack = Color.black;
            gameOutcomeText.colorGradient = new VertexGradient(
                colorRed,
                colorBlack,
                colorRed,
                colorBlack);
        }
    }
}
