using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    #region FIELDS
    
    // Vida del jugador
    public int life;
    // Vida REAL del jugador
    private int _currentLife;
    // Tiempo total del jugador
    public int time;
    
    #endregion
    
    #region SINGLETON

    // Unica instancia de la clase
    private static GameManager _instance = null;

    /// <summary>
    /// Propiedad para acceder al singleton
    /// </summary>
    public static GameManager SINGLETON
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Game Manager no inicializado");

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
    /// Aumenta la vida(actual) del jugador.
    /// </summary>
    public void IncreaseLife() { _currentLife += 1; }
    /// <summary>
    /// Disminuye la vida(actual) del jugador.
    /// </summary>
    public void DecreaseLife() { _currentLife -= 1; }
    
    #endregion
}