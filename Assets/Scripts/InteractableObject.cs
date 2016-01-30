﻿using UnityEngine;
using System.Collections;

public class InteractableObject : ClickableObject {
    /// <summary>
    /// On click pressed method
    /// </summary>
    public override void OnClickPressed()
    {

	}

    /// <summary>
    /// On right click pressed method
    /// </summary>
    public override void OnReleasePressed()
    {
        Debug.Log("INTERACTABLE: Click derecho");
    }

}
