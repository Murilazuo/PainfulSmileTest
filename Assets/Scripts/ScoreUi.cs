using UnityEngine;
using UnityEngine.UI;
public class ScoreUi : MonoBehaviour
{
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }
    public void UpdateScore(int score)
    {
        text.text = string.Format("Score: {0}", score);
    }
}
