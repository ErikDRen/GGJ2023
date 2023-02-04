using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiNode : MonoBehaviour
{
    public Transform GripTransform;
    public Transform ParentTransform;

    public bool used = false;
    public float RotationSpeed;

    [SerializeField] private EnemiNode _possibleChild;
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
}
