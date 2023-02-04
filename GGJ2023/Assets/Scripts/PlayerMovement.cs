using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _possibleChild;
    [SerializeField] private Transform _currentParent => transform.parent;

    public void ClickTrigger()
    {
        Debug.Log("Try Inject Child");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != transform.parent)
        {
            _possibleChild.parent = other.transform.parent;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _possibleChild = null;
    }
}
