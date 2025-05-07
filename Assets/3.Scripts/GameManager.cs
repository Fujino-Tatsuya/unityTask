using System.ComponentModel.Design;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static float survivalTime;
    public static bool isGameOver = false;

    public TextMeshProUGUI timeText;

    void Awake()
    {
        Instance = this;
        survivalTime = 60.0f;
    }

    void Update()
    {
        if (!isGameOver)
        {
            survivalTime -= Time.deltaTime;

            if(survivalTime <= 9.9f)
            {
                timeText.text = $"{survivalTime:F1}";
            }
            else
            {
                timeText.text = $"{(int)survivalTime}"; 
            }
        }
    }
}
