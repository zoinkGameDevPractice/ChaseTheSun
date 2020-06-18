using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Rigidbody2D player;
    public TextMeshProUGUI text;

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
        Display(topMeters);
    }

    void Display(int i)
    {
        text.text = i.ToString() + "M";
    }
}
