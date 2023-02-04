using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public EnemiNode CurrentNode;

    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool _shouldRotate = false;

    [SerializeField] private UnityEvent OnLooseLife;

    /// <summary>
    /// if node is a rotate node, rotate around parent
    /// </summary>
    private void Update()
    {
        if (_shouldRotate)
        {
            Debug.Log("should rotate");
            CurrentNode.transform.RotateAround(CurrentNode.ParentTransform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    /// <summary>
    /// On click event we check if we can inject a proxy node
    /// if we can, we now control this new node
    /// if not we loose a life
    /// </summary>
    public void ClickTrigger()
    {
        Debug.Log("On Click -> Try Inject Child");
        if (CurrentNode != null)
        {
            EnemiNode newNode = CurrentNode.TryToInfect();
            if (newNode != null)
            {
                newNode.ParentTransform = CurrentNode.GripTransform;
                CurrentNode = newNode;
                CurrentNode.used = true;
                rotationSpeed = newNode.RotationSpeed;
                _shouldRotate = true;
                Debug.Log("Injection succesfull");
            }
            else
            {
                Debug.Log("You missed your shot! -> onLooseLife Invoked");
                OnLooseLife?.Invoke();
            }
        }
    }
}
