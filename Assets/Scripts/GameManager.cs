using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    #region FIELDS
    
    // Vida del jugador
    public int life;
    
    // Tiempo total del jugador
    public float time;
    
    // Array con las ordenes que pueden mandar los monigotes
    public List<GameObject> orders = null;

    // Array que contiene la informacion de las ordenes que ya han sido mandadas
    private List<bool> avaibleOrders = null;

    // Vida REAL del jugador
    private int _currentLife;

    // Vida REAL del jugador
    private float _currentTime;

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
        InitOrders();
    }

    /// <summary>
    /// Raises the destroy event.
    /// </summary>
    private void OnDestroy()
    {
        _instance = null;
        orders = null;
        avaibleOrders = null;
    }

    /// <summary>
    /// Raises the destroy event.
    /// </summary>
    void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= time)
        {
            GameOver();
        }
    }

    #endregion
    
    #region CUSTOM_METHODS

    /// <summary>
    /// Inicializa los arrays que contienen la informacion de las ordenes
    /// que dan los monigotes
    /// </summary>
    private void InitOrders()
    {
        avaibleOrders = new List<bool>();

        //Inicializo el array de booleanos a true
        for (int i = 0; i < orders.Count; ++i)
        {
            avaibleOrders.Add(true);
        }
    }

    /// <summary>
    /// Aumenta la vida(actual) del jugador.
    /// </summary>
    public void IncreaseLife() { _currentLife += 1; }

    /// <summary>
    /// Disminuye la vida(actual) del jugador.
    /// </summary>
    public void DecreaseLife() { _currentLife -= 1; }

    /// <summary>
    /// Devuelve a los Monigotes que dan ordenes la siguiente orden a ejecutar
    /// </summary>
    /// <returns></returns>
    public GameObject GetNextOrder(int pos)
    {
        pos = Random.Range(0, orders.Count - 1);
        while (!avaibleOrders[pos])
        {
            pos = (pos + 1) % orders.Count;
        };

        return orders[pos];
    }

    /// <summary>
    /// Cancela la orden indicada
    /// </summary>
    /// <param name="pos"></param>
    public void CancelOrder(int pos)
    {
        avaibleOrders[pos] = true;
    }

    /// <summary>
    /// Controla el final de partida, playeara la escena de la invocacion 
    /// final
    /// </summary>
    private void GameOver()
    { 
    }

    #endregion
}