using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiNode : MonoBehaviour
{
    public Transform GripTransform;
    public Transform ParentTransform;
    [SerializeField]
    public PlayerMovement.PlayerState status;
    public bool used = false;
    public float RotationSpeed;

    [SerializeField] private EnemiNode _possibleChild;
    [Header("Moves")]
    public float _speed;
    public Rigidbody _rb;
    public float _acceleration = 1;
    private int direction = 1;
    /// <summary>
    /// return any proxy node of this node
    /// </summary>
    /// <returns></returns>
    public EnemiNode TryToInfect()
    {
        EnemiNode node = null;

        if (_possibleChild != null)
        {
            node = _possibleChild;
        }

        return node;
    }

    /// <summary>
    /// check if we enter proxy node range
    /// if we do this node is now a potential child
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TriggerEnter");

        if (_possibleChild == null)
        {
            EnemiNode n = other.transform.GetComponent<EnemiNode>();
            if (n != null && !n.used)
            {
                _possibleChild = other.transform.GetComponent<EnemiNode>();
            }
        }
    }

    /// <summary>
    /// check if we exit proxy node range
    /// if we do, reset our current potential child
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("TriggerExit");

        _possibleChild = null;
    }
    public void zigZag()
    {
        float frameDependentSpeed = _speed * Time.deltaTime;

        Vector3 dir = new Vector3(0, 0, 0);

        dir.x += 1 * direction;
        dir.z += 1;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            direction = -direction;
        }

        dir = dir.x * transform.right + dir.z * transform.forward;
        dir *= frameDependentSpeed;
        Vector3 TargetVelocity = new Vector3(dir.x, _rb.velocity.y, dir.z);
        Debug.Log(dir);
        _rb.velocity = Vector3.Lerp(_rb.velocity, TargetVelocity, Time.deltaTime * _acceleration);
    }
}
