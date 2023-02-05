using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiNode : MonoBehaviour
{

    public Transform GripTransform;
    public Transform ParentTransform;
    [SerializeField]
    public PlayerMovement.PlayerState status;
    public bool used = false;
    public float RotationSpeed;

    [SerializeField] private EnemiNode _possibleChild;
    [Header("Enemi Move")]
    public float _speed;
    public Rigidbody _rb;
    public float _acceleration = 1;
    public int directionX = 1;
    public int directionZ = 1;
    public bool isVertical;
    public bool isStraight;
    public int straight_DirectionX = 1;
    public int straight_DirectionZ = 1;

    [SerializeField] private UnityEvent onInfectedEvent;

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
            if (_rb != null)
            {
                Debug.Log("azkdhazhfazihihefizehihofihhfzi");
                _rb.velocity = Vector3.zero;
            }
            onInfectedEvent?.Invoke();
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

        EnemiNode n = other.transform.GetComponent<EnemiNode>();
        if (n != null)
        {
            if (n._possibleChild == null)
            {
                Debug.Log(gameObject.transform.parent.name + " " + n);
                if (n != null && !used)
                {
                    n._possibleChild = this;
                    //_possibleChild = other.transform.GetComponent<EnemiNode>();
                }
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

        EnemiNode n = other.transform.GetComponent<EnemiNode>();
        if (n != null)
        {
            //n._possibleChild = this;
            n._possibleChild = null;
            //_possibleChild = other.transform.GetComponent<EnemiNode>();
        }
    }
    public void zigZag()
    {
        float frameDependentSpeed = _speed * Time.deltaTime;

        Vector3 dir = new Vector3(0, 0, 0);


        dir.x += directionX * 1;
        dir.z += directionZ * 1;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isStraight)
            {
                if (directionZ == 0)
                {
                    Debug.Log(straight_DirectionZ);
                    directionZ = straight_DirectionZ;
                    directionX = 0;
                }
                else
                {
                    directionX = straight_DirectionX;
                    directionZ = 0;
                }
            }
            else
            {
                if (isVertical)
                {
                    directionX = -directionX;
                }
                else
                {
                    directionZ = -directionZ;
                }
            }
        }

        dir = dir.x * transform.right + dir.z * transform.forward;
        dir *= frameDependentSpeed;
        Vector3 TargetVelocity = new Vector3(dir.x, _rb.velocity.y, dir.z);
        Debug.Log(dir);
        _rb.velocity = Vector3.Lerp(_rb.velocity, TargetVelocity, Time.deltaTime * _acceleration);
    }
}
