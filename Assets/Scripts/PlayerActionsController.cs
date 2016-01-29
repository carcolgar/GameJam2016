using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerActionsController : MonoBehaviour {
    public float speed = 5;

    Vector2 originalPosition;
    Vector2 targetPosition;
    Vector2 finalPosition;

    Dictionary<string, System.Action<Vector2>> actions;

    void Start()
    {
        originalPosition = transform.position;
        targetPosition = originalPosition;
        AddMethods();
    }

    void AddMethods() {
        actions = new Dictionary<string, System.Action<Vector2>>(){
            {"Walkable", (hitPoint) => WalkToPoint(hitPoint)},
            {"Player", (hitPoint) => RiseArms(hitPoint)},
            {"InteractableObject", (hitPoint) => InteractWithObject(hitPoint)}
        };

    }

    
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            EnterAction();
        }

        Debug.Log(targetPosition);
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
        if (Mathf.Abs(transform.position.x - finalPosition.x) < 0.001)
        {
            transform.position = targetPosition;
            targetPosition = originalPosition;
        }

	}

    void EnterAction() {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
        if (hit.collider != null && actions.ContainsKey(hit.collider.tag)) {
            actions[hit.collider.tag](hit.point);
        }
    }

    void WalkToPoint(Vector2 hitPoint) {
        Debug.Log("WalkToPoint");
        targetPosition = hitPoint;
    }

    void RiseArms(Vector2 zero){
        Debug.Log("Animate Arms");
    }

    void InteractWithObject(Vector2 hitPoint) {
        targetPosition = hitPoint;
        Debug.Log("Interacting");
    }
    
}
