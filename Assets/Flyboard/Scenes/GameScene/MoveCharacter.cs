using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    [SerializeField] Transform leftController;
    [SerializeField] Transform rightController;

    [SerializeField] float forceSize;
    [SerializeField] float finalHeight;

    [SerializeField] Transform model;

    [SerializeField] DataManager dataManager;

    [SerializeField] float rotateSpeed = 5;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float leftTrigger = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        float rightTrigger = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        float trigger = (leftTrigger + rightTrigger) / 2;

        Vector3 dir = (leftController.up + rightController.up) / 2;
        Vector3 water = dir * Mathf.Max(0, trigger - (transform.position.y / finalHeight)) * forceSize;
        
        
        if (dataManager.status == 2) GetComponent<Rigidbody>().AddForce(water);

        model.localPosition = transform.position - new Vector3(0,1,0);



        Vector2 stick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        transform.Rotate(Vector3.up, stick.x * rotateSpeed * Time.deltaTime);
    }
}
