using UnityEngine;
using System.Collections;

public class PickableObject : ClickableObject
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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

