using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D player;
    [Space]
    public TextMeshProUGUI meterText;
    public TextMeshProUGUI topMeterText;

    Vector2 initialPos;
    int meters;
    int topMeters;

    void Start()
    {
        initialPos = player.transform.position;
    }

    void Update()
    {
        CalculateMeters();
    }

    void CalculateMeters()
    {
        meters = Mathf.RoundToInt(Vector2.Distance(new Vector2(0, player.transform.position.y), new Vector2(0, initialPos.y)));
        if (topMeters <= meters)
        {
            topMeters = meters;
        }
        if (PlayerPrefs.GetInt("HighScore", 0) <= topMeters) { PlayerPrefs.SetInt("HighScore", topMeters); }
        Display(topMeters);
    }

    void Display(int i)
    {
        meterText.text = i.ToString() + "M";
        topMeterText.text = "Top: " + PlayerPrefs.GetInt("HighScore", 0).ToString() + "M";
    }

    //For Developement
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        print("Deleted the High Score");
    }
}
