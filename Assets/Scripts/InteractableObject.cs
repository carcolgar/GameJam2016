using UnityEngine;
using System.Collections;

public class InteractableObject : ClickableObject {
    bool inConflict;
    MonkRequest monkRequest;

    /// <summary>
    /// On click pressed method
    /// </summary>
    public override void OnClickPressed()
    {
        if (inConflict) {
            EndConflict();
        }
    }

    /// <summary>
    /// On right click pressed method
    /// </summary>
    public override void OnReleasePressed()
    {
        Debug.Log("INTERACTABLE: Click derecho");
    }

    public virtual void StartConflict(MonkRequest monkRequest)
    {
        this.monkRequest = monkRequest;
        inConflict = true;
    }

    public virtual void EndConflict()
    {
        inConflict = false;
        monkRequest.CompleteRequest(this.gameObject);
    }

}
