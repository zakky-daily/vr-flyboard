using UnityEngine;

public class BirdGenerator : MonoBehaviour
{
    [SerializeField] GameObject BirdPrefab;
    [SerializeField] DataManager dataManager;
 
    void Start()
    {
        for (int i=0; i<10; i++)
        {
            GameObject obj = Instantiate(BirdPrefab);
            obj.GetComponent<BirdController>().dataManager = dataManager;
        }
    }

    void Update()
    {
        
    }
}
