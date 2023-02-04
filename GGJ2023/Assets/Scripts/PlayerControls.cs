using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.InputSystem.InputAction;

public class PlayerControls : MonoBehaviour
{

    [SerializeField] private PlayerMovement _movement;


    public void Click(CallbackContext callbackContext)
    {
        //Debug.Log("je vais tuer la personne à coté de moi");
        // if u don't precise performed, is also called for started and canceled
        if (callbackContext.performed)
        {
            _movement.ClickTrigger();
        }
    }


}