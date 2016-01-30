using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickableObject : MonoBehaviour
{
    #region PARAMETERS
    
    /// <summary>
    /// Object sound
    /// </summary>
    public AudioSource sound;
    
    /// <summary>
    /// Object image
    /// </summary>
    public SpriteRenderer image;

    /// <summary>
    /// Posicion en la que colocaremos al player 
    /// para coger el objeto
    /// </summary>
    public Vector3 takeObjectPosition;

    #endregion

    #region UNITY_METHODS

    // Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    }
    
    #endregion

    #region CUSTOM_METHODS

    /// <summary>
    /// Play current sound attached to the object
    /// </summary>
    public virtual void PlaySound() 
    {
        sound.Play();
    }

    /// <summary>
    /// On left click pressed method
    /// </summary>
    public virtual void OnClickPressed()
    {
    }

    /// <summary>
    /// On right click pressed method
    /// </summary>
    public virtual void OnReleasePressed()
    {
    }

    #endregion

}
