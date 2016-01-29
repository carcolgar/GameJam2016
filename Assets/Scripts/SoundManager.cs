using UnityEngine;

public class SoundManager : MonoBehaviour {
    
    #region FIELDS  
    // Futuras instancias de sonidos
    public AudioSource musicSource;
    #endregion
    
    #region SINGLETON

    // Unica instancia de la clase
    private static SoundManager _instance = null;

    /// <summary>
    /// Propiedad para acceder al singleton
    /// </summary>
    public static SoundManager SINGLETON
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Sound Manager no inicializado");

            return _instance;
        }
    }

    #endregion
    
    #region UNITY_METHODS
    
	/// <summary>
    /// Awake this instance.
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(this);
        _instance = this;
    }

    /// <summary>
    /// Raises the destroy event.
    /// </summary>
    private void OnDestroy()
    {
        _instance = null;
    }
    
    #endregion
    
    #region CUSTOM_METHODS
    
    /// <summary>
    /// Se usa para hacer play de efectos de sonido.
    /// </summary>
    public void PlayAudio(AudioClip clip)
    {
        // Play de los distintos sonidos (supongo)
    }
    
    #endregion
}
