using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerActionsController : MonoBehaviour
{
    #region FIELDS

    //Velocidad del jugador al moverse
    public float speed = 5;

    //Controlador de animaciones
    public PlayerAnimationsController playerAnimationsController;

    // Objeto que lleva el jugador 
    GameObject carriedObject;
    public GameObject CarriedObject {
        get {
            return carriedObject;
        }
        set {
            carriedObject = value;
        }
    }

    //Objetivo del jugador
    Vector2 targetPosition;

    //Objeto a ser recogido
    bool isMovingToCarry;

    #endregion

    #region UNITY_METHODS
    
    void Update () {
        if (Mathf.Abs(transform.position.x - targetPosition.x) > 0.01)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
            if (carriedObject != null && isMovingToCarry) {
                isMovingToCarry = false;
                carriedObject.GetComponent<ClickableObject>().OnClickPressed();
            }
        }
        else {
            transform.position = targetPosition;
            playerAnimationsController.Idle();
        }
	}
    #endregion

    #region CUSTOM_METHODS
    //ACCIONES
    public void WalkToPoint(Vector2 targetPoint) {
        Debug.Log("WalkToPoint");
        targetPosition = targetPoint;
        //Call WALK animation
        playerAnimationsController.Walk();
    }

    public void RiseArms(){
        Debug.Log("Animate Arms");
        ///Call RISEARMS animation
    }

    public void InteractWithObject(GameObject clickable) {
        isMovingToCarry = true;
        carriedObject = clickable;
        targetPosition = clickable.GetComponent<ClickableObject>().TakeObjectPosition;
        //Call INTERACT animation
    }
    #endregion

}
