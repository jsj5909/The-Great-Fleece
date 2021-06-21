using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
   
    [SerializeField]
    int _triggerId;

    [SerializeField]
    Transform _cameraAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Camera Trigger: " + _triggerId);

            Camera.main.transform.position = _cameraAngle.position ;
            Camera.main.transform.rotation = _cameraAngle.rotation;
        }
    }


}
