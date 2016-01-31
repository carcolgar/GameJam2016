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
    private Vector2 takeObjectPosition;
    public Vector2 TakeObjectPosition {
        get {
            return takeObjectPosition;
        }
    }
    
    /// <summary>
    /// Sonido que reproduce el objeto al interactuar con el
    /// </summary>
    public FMODManager.Sounds interactSound = FMODManager.Sounds.NONE;

    #endregion

    #region UNITY_METHODS

    // Use this for initialization
	protected void Start () {
        takeObjectPosition = transform.FindChild("TakeObjectPosition").transform.position;
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
        FMODManager.SINGLETON.PlayOneShot(FMODManager.Sounds.PickObject);
        FMODManager.SINGLETON.PlayOneShot(interactSound);
    }

    /// <summary>
    /// On right click pressed method
    /// </summary>
    public virtual void OnReleasePressed()
    {
        FMODManager.SINGLETON.PlayOneShot(FMODManager.Sounds.LeaveObject);
    }

    #endregion

}
