using UnityEngine;
using UnityEngine.UI;

public enum SettingsTime{ SessionTime, EnemySpawnTime}
public class SessionTimeController : MonoBehaviour
{
    [SerializeField] private SettingsTime settingsTime;
    [SerializeField] private Text SessiontTimeText;
    public void SetSessionTimeText(Slider slider)
    {
        SessiontTimeText.text = TimeConverter(slider.value);

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
