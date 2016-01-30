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

    //Diccionario de acciones que puede hacer el personaje
    Dictionary<string, System.Action<Vector2>> actions;
    #endregion

    #region UNITY_METHODS
    void Start()
    {
        AddActions();
    }
    
    void Update () {
        if (Mathf.Abs(transform.position.x - targetPosition.x) > 0.01)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
        }
        else {
            transform.position = targetPosition;
            playerAnimationsController.Idle();
        }
	}
    #endregion

    #region CUSTOM_METHODS
    //Añadir acciones del jugador
    void AddActions()
    {
        actions = new Dictionary<string, System.Action<Vector2>>(){
            {"Walkable", (hitPoint) => WalkToPoint(hitPoint)},
            {"Player", (hitPoint) => RiseArms(hitPoint)},
            {"InteractableObject", (hitPoint) => InteractWithObject(hitPoint)}
        };
    }

    //Llamada a la acción
    public void EnterAction(string clickedObjectTag) {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
        if (hit.collider != null && actions.ContainsKey(hit.collider.tag)) {
            actions[hit.collider.tag](hit.point);
        }
    }

    //ACCIONES
    void WalkToPoint(Vector2 hitPoint) {
        Debug.Log("WalkToPoint");
        targetPosition = hitPoint;
        //Call WALK animation
        playerAnimationsController.Walk();
    }

    void RiseArms(Vector2 zero){
        Debug.Log("Animate Arms");
        ///Call RISEARMS animation
    }

    void InteractWithObject(Vector2 hitPoint) {
        targetPosition = hitPoint;
        Debug.Log("Interacting");
        //Call 
    }
    #endregion

}
