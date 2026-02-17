using TMPro;
using UnityEngine;

public class DisplayTimeAndScore : MonoBehaviour
{
    [SerializeField] DataManager dataManager;

    void Start()
    {
        
    }

    void Update()
    {   
        int time = dataManager.status==1 ? 0 : Mathf.CeilToInt(dataManager.time);
        int score = dataManager.score;
        GetComponent<TextMeshProUGUI>().text = $"Time {time / 60}:{time % 60:D2}\nScore {score}";
    }
}
