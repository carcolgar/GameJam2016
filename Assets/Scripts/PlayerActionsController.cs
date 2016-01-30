using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerActionsController : MonoBehaviour
{
    #region FIELDS

    //Velocidad del jugador al moverse
    public float speed = 5;
    
    private bool isFacingRight = false;
    
    // Vector usado para rotar el sprite cuando cambia de dirección
    private Vector3 rotationVector = new Vector3(0,180,0);
    
    private bool isRisingArms = false;

    //Controlador de animaciones
    public PlayerAnimationsController playerAnimationsController;

    // Objeto que lleva el jugador 
    GameObject carriedObject;
    public GameObject CarriedObject
    {
        get
        {
            return carriedObject;
        }
        set
        {
            carriedObject = value;
        }
    }
    
    public bool HasHandsUp {
        get { return isRisingArms; }
    }

    //Objetivo del jugador
    Vector2 targetPosition;

    //Objeto a ser recogido
    bool isMovingToCarry;

    #endregion

    #region UNITY_METHODS

	void Start()
	{
		targetPosition = transform.position;
	}

    void Update()
    {
        if (Mathf.Abs(transform.position.x - targetPosition.x) > 0.01)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
        }
        else
        {
            transform.position = targetPosition;
            if (!isRisingArms)
            {
                playerAnimationsController.Idle();
            }
            if (carriedObject != null && isMovingToCarry)
            {
                isMovingToCarry = false;
                carriedObject.GetComponent<ClickableObject>().OnClickPressed();
                playerAnimationsController.ÍnteractWithObject();
            }
        }
    }
    #endregion

    #region CUSTOM_METHODS
    //ACCIONES
    public void WalkToPoint(Vector2 targetPoint)
    {
        Debug.Log("WalkToPoint");
        targetPosition = targetPoint;
        //Call WALK animation
        rotatePlayerIfNeeded();
        if (isRisingArms) {
            playerAnimationsController.DownArms();
            isRisingArms = false; 
        } else playerAnimationsController.Walk();
    }

    public void RiseArms()
    {
        Debug.Log("Animate Arms");
        isRisingArms = true;
        ///Call RISEARMS animation
        playerAnimationsController.RiseArms();
    }

    public void InteractWithObject(GameObject clickable)
    {
        isMovingToCarry = true;
        carriedObject = clickable;
        targetPosition = clickable.GetComponent<ClickableObject>().TakeObjectPosition;
        rotatePlayerIfNeeded();      
        if (isRisingArms) {
            playerAnimationsController.DownArms();
            isRisingArms = false; 
        } else playerAnimationsController.Walk();
        //Call INTERACT animation
    }
    
    private void rotatePlayerIfNeeded () {
        if ((transform.position.x < targetPosition.x) != isFacingRight) {
            transform.Rotate(rotationVector);
            isFacingRight = !isFacingRight;
        }
    }
    
    private IEnumerator downArmsAndWalk () {
        playerAnimationsController.DownArms();
        isRisingArms = false;
        yield return new WaitForSeconds(0.25f);
        playerAnimationsController.Walk();
        
    }
    
    #endregion

}