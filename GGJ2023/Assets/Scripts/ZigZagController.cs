using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZigZagController : MonoBehaviour
{
    [SerializeField]
    public float _speed;
    [SerializeField]
    private Rigidbody _rb;
    [SerializeField]
    public float _acceleration = 1;
    public int direction = 1;
    public void Update()
    {
        float frameDependentSpeed = _speed * Time.deltaTime;

        Vector3 dir = new Vector3(0, 0, 0);

        dir.x += 1 * direction;
        dir.z += 1;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction=-direction;
        }

        dir = dir.x * transform.right + dir.z * transform.forward;
        dir *= frameDependentSpeed;
        Vector3 TargetVelocity = new Vector3(dir.x, _rb.velocity.y, dir.z);
        Debug.Log(dir);
        _rb.velocity = Vector3.Lerp(_rb.velocity, TargetVelocity, Time.deltaTime * _acceleration);
    }
}
