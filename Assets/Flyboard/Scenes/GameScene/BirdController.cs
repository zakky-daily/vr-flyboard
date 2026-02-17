using System.Collections;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public DataManager dataManager;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, Random.Range(0f,360f), 0f);
        RandomPosition();
    }

    void Update()
    {
        
    }

    void RandomPosition()
    {
        transform.position = new Vector3(Random.Range(-20f,20f), Random.Range(10f, 30f), Random.Range(-20f,20f));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (dataManager.status == 2)
        {
            dataManager.score += 10;
            RandomPosition();

            GetComponent<AudioSource>().Play();

            StartCoroutine(Vibrate(duration:0.1f, amplitude:10, controller:OVRInput.Controller.LTouch));
            StartCoroutine(Vibrate(duration:0.1f, amplitude:10, controller:OVRInput.Controller.RTouch));
        }
    }

    public static IEnumerator Vibrate(float duration = 0.1f, float frequency = 0.1f, float amplitude = 0.1f, OVRInput.Controller controller = OVRInput.Controller.Active) {
        OVRInput.SetControllerVibration(frequency, amplitude, controller);
        yield return new WaitForSeconds(duration);
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}
