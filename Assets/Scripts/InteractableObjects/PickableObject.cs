using UnityEngine;
using System.Collections;

public class PickableObject : ClickableObject{
    /// <summary>
    /// On click pressed method
    /// </summary>
    public override void OnClickPressed()
    {
        Debug.Log("PICKABLE: Click izquierdo");
    }

    /// <summary>
    /// On right click pressed method
    /// </summary>
    public override void OnReleasePressed()
    {
        Debug.Log("PICKABLE: Click derecho");
    }
}

