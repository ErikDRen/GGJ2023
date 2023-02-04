using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;


    public void Click(CallbackContext callbackContext)
    {
        // if u don't precise performed, is also called for started and canceled
        if (callbackContext.performed)
        {
            _movement.ClickTrigger();
        }
    }
}
