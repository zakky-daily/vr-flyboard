using TMPro;
using UnityEngine;

public class DisplayCountdown : MonoBehaviour
{
    [SerializeField] DataManager dataManager;

    void Start()
    {
        
    }

    void Update()
    {
        int time = Mathf.CeilToInt(dataManager.time);
        if (dataManager.status == 1)
        {
            GetComponent<TextMeshProUGUI>().text = time.ToString();
        }
        else if (dataManager.status == 2)
        {
            if (time == 60) GetComponent<TextMeshProUGUI>().text = "start!";
            if (8 <= time && time < 10) GetComponent<TextMeshProUGUI>().text = "<size=24>10 seconds left</size>";
            else GetComponent<TextMeshProUGUI>().text = "";
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = "";
        }
    }
}
