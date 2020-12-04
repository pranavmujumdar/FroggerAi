using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{

    public Text scoreText;
    private static int score = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        //score = 0;
        resetScore();
    }

    public void resetScore()
    {
        score = 0;
        setScoreText();
    }

    public void scored()
    {
        score += 1;
        setScoreText();
    }
    void setScoreText()
    {
        scoreText.text = score.ToString();
    }


}
