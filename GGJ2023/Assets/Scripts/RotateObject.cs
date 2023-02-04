using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] Vector3 rotate;
    void Update()
    {
        gameObject.transform.Rotate(rotate * Time.deltaTime);
    }
}
