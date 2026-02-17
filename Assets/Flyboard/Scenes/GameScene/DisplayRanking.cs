using TMPro;
using UnityEngine;

public class DisplayRanking : MonoBehaviour
{
    [SerializeField] DataManager dataManager;
    [SerializeField] TextMeshProUGUI rankingText;

    [SerializeField] Transform character;

    void Start()
    {
        
    }

    void Update()
    {
        if (dataManager.status == 0)
        {
            GetComponent<CanvasGroup>().alpha = 1;
            rankingText.text = $"1st: {dataManager.ranking[0]}pt\n2nd: {dataManager.ranking[1]}pt\n3rd: {dataManager.ranking[2]}pt";
        }
        else
        {
            GetComponent<CanvasGroup>().alpha = 0;
        }
    }
}
