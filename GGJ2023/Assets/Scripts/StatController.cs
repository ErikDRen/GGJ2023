//using System.Collections;
//using System.Collections.Generic;
//using System;
//using UnityEngine;

//public class PlayerMovement : MonoBehaviour
//{


//    public enum PlayerState { idle, rotation, zigzag }
//    private PlayerState status;
//    [SerializeField] private Transform _possibleChild;
//    [Header("Moves")]
//    public float _speed;
//    public Rigidbody _rb;
//    public float _acceleration = 1;
//    private int direction = 1;
//    [SerializeField] private Transform _currentParent => transform.parent;

//    private void Start()
//    {
//        status = PlayerState.idle;
//    }
//    private void Update()
//    {
//        switch (status)
//        {
//            case PlayerState.zigzag:
//                zigZag();
//                break;
//            case PlayerState.rotation:

//                break;

//        }
//    }
//public void zigZag()
//{
//    float frameDependentSpeed = _speed * Time.deltaTime;

//    Vector3 dir = new Vector3(0, 0, 0);

//    dir.x += 1 * direction;
//    dir.z += 1;
//    if (Input.GetKeyUp(KeyCode.Space))
//    {
//        direction = -direction;
//    }

//    dir = dir.x * transform.right + dir.z * transform.forward;
//    dir *= frameDependentSpeed;
//    Vector3 TargetVelocity = new Vector3(dir.x, _rb.velocity.y, dir.z);
//    Debug.Log(dir);
//    _rb.velocity = Vector3.Lerp(_rb.velocity, TargetVelocity, Time.deltaTime * _acceleration);
//}
//    public void ClickTrigger()
//    {
//        if (status == PlayerState.rotation)
//        {
//            status = PlayerState.zigzag;
//        }
//        else
//        {
//            status = PlayerState.rotation;
//        }
//        Debug.Log(status);
//        Debug.Log("Try Inject Child");
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.transform.parent != transform.parent)
//        {
//            _possibleChild.parent = other.transform.parent;
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        _possibleChild = null;
//    }

//}
