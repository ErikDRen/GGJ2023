using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] Camera _cam;
    private float camFieldOfView;
    [SerializeField] private float zoomSpeed;
    private float mouseScrollInput;
    // Start is called before the first frame update
    void Start()
    {
        camFieldOfView = _cam.fieldOfView;

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(camFieldOfView);
        //camFieldOfView += 10 * zoomSpeed;
        camFieldOfView = Mathf.Clamp(camFieldOfView, 30, 80);

        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("click on space for transition");
            _cam.fieldOfView = Mathf.Lerp(_cam.fieldOfView, camFieldOfView, zoomSpeed);
        }

       
    }
}
