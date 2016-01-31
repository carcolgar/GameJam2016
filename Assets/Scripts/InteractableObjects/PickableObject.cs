using UnityEngine;
using System.Collections;

public class PickableObject : ClickableObject{
    /// <summary>
    /// On click pressed method
    /// </summary>
    public override void OnClickPressed()
    {
        base.OnClickPressed();
        
        Debug.Log("PICKABLE: Click izquierdo");
		GameManager.SINGLETON.Player.realCarriedObject = gameObject;
		gameObject.SetActive (false);
    }

    /// <summary>
    /// On right click pressed method
    /// </summary>
    public override void OnReleasePressed()
    {
        base.OnReleasePressed();
        
        Debug.Log("PICKABLE: Click derecho");
		GameManager.SINGLETON.Player.realCarriedObject = null;
		gameObject.SetActive (true);
    }
}

