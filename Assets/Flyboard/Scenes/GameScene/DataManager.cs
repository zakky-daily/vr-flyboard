using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public float time = 60;
    public int score = 0;
    public int status = 0;
    public List<int> ranking = new List<int>(){0, 0, 0};
    public float freeze = 0;

    [SerializeField] GameObject character;

    void Start()
    {
        
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0) {

            if (status == 1)
            {
                status = 2;
                time = 60;
            }
            else
            {
                if (status == 2) {
                    status = 0;
                    character.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                    character.transform.position = new Vector3(0,2,0);
                    freeze = 10;

                    ranking.Add(score);
                    ranking.Sort();
                    ranking.Reverse();
                    ranking.RemoveAt(ranking.Count - 1);
                }
                time = 0;
            }
        }

        freeze -= Time.deltaTime;


        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            if (status == 0)
            {
                status = 1;
                time = 3;
                score = 0;
            }
            else
            {
                character.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
                character.transform.position = new Vector3(0,2,0);
            }
        }
    }
}
