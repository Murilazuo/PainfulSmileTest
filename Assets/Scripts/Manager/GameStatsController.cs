using UnityEngine;
using UnityEngine.UI;

public enum SettingsTime{ SessionTime, EnemySpawnTime}
public class GameStatsController : MonoBehaviour
{
    [SerializeField] private SettingsTime settingsTime;
    [SerializeField] private Text SessiontTimeText;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();

        switch (settingsTime)
        {
            case SettingsTime.SessionTime:
                slider.value = GameManager.gameSession / 60;
                break;
            case SettingsTime.EnemySpawnTime:
                slider.value = GameManager.timeToSpanwEnemy / 60;
                break;
        }
    }
    public void SetSlider()
    {
        SessiontTimeText.text = TimeConverter(slider.value);

        UpdateValue();
    }

    private void UpdateValue()
    {
        switch (settingsTime)
        {
            case SettingsTime.SessionTime:
                GameManager.gameSession = slider.value * 60;
                break;
            case SettingsTime.EnemySpawnTime:
                GameManager.timeToSpanwEnemy = slider.value * 60;
                break;
        }
    }

    public static string TimeConverter(float value)
    {
        decimal decimalValue = (decimal)value;

        decimal minutes = decimal.Truncate(decimalValue);
        decimal seconds = decimal.Truncate((decimalValue - minutes) * 60);

        string zero = string.Empty;

        if (seconds < 10)
        {
            zero = "0";
        }

        string toReturn = minutes + ":" + zero + seconds + " min";

        return toReturn;
    }
}
