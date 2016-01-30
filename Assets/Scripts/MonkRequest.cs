using UnityEngine;
using System.Collections;

public class MonkRequest : MonoBehaviour 
{

	#region FIELDS
    
	/// <summary>
	/// Tiempo minimo y maximo que estara el monje sin pedir cosas
	/// </summary>
	public Vector2 minMaxTimeWithoutRequest = new Vector2(1.0f, 5.0f);
    
    /// <summary>
    /// Tiempo minimo y maximo para cumplir una peticion del monje
    /// </summary>
    public Vector2 minMaxTimeForCompleteRequest = new Vector2(5.0f, 10.0f);

    /// <summary>
    /// Indice del objeto de la orden (para devolverselo al GameManager)
    /// </summary>
    private int _orderIndex = -1;
    
    /// <summary>
    /// Puntero al GameObject de la orden actual
    /// </summary>
    private GameObject _currentOrderGO = null;
    
    /// <summary>
    /// Puntero a la corrutina de comportamiento en ejecucion
    /// </summary>
    private IEnumerator _currentCoroutine = null;
    
	public Bubble bubble;

	#endregion
    

    #region UNITY_METHODS

	/// <summary>
    /// Update del componente
    /// </summary>
	private void FixedUpdate () 
    {
        if(_currentCoroutine == null)
        {
            _currentCoroutine = MonkBehaviour();
            StartCoroutine(_currentCoroutine);
        } 
	}
    
    #endregion
    
    
    #region CUSTOM_METHODS
    
    /// <summary>
    /// Avisa al monje de que se debe completar su peticion
    /// </summary>
    /// <param name="resultGO"> Objeto que se pasa al monje para la mision </param>
    public void CompleteRequest(GameObject resultGO)
    {
        // Detenemos el comportamiento actual
        StopCoroutine(_currentCoroutine);        
        
        // Comprobamos resultado
        if(_currentOrderGO!=null && _currentOrderGO == resultGO)
        {
            // Correcto
            Debug.Log("[MonkRequest::MonkBehaviour] Completando peticion: CORRECTO!");
            GameManager.SINGLETON.OrderCompleted(true, _orderIndex);
        }
        else
        {
            // Incorrecto
            Debug.Log("[MonkRequest::MonkBehaviour] Completando peticion: FALLO!");
            GameManager.SINGLETON.BadRequestedReceived();
        }
		bubble.DisableBubble ();
        ResetBehaviourVars();
    } 
    
    /// <summary>
    /// Corrutina del comportamiento del monje
    /// </summary>
    private IEnumerator MonkBehaviour()
    {
        Debug.Log("[MonkRequest::MonkBehaviour] Esperando");
        
        // Espera hasta pedir nueva orden
        yield return new WaitForSeconds(Random.Range(minMaxTimeWithoutRequest.x, minMaxTimeWithoutRequest.y));
        
        Debug.Log("[MonkRequest::MonkBehaviour] Orden pedida");
        // Pedimos la nueva orden
        _currentOrderGO = GameManager.SINGLETON.GetNextOrder(ref _orderIndex);
		bubble.ActivateBubble (_currentOrderGO.GetComponentInChildren<SpriteRenderer> ());
        
        FMODManager.SINGLETON.PlayOneShot(FMODManager.Sounds.Request);
        
        // Mostramos la informacion de la orden
        // @TODO
        
        Debug.Log("[MonkRequest::MonkBehaviour] Esperando cumplirla");
        // Contador hasta final de tiempo hasta cumplir la orden
        yield return new WaitForSeconds(Random.Range(minMaxTimeForCompleteRequest.x, minMaxTimeForCompleteRequest.y));
        
        Debug.Log("[MonkRequest::MonkBehaviour] Orden Timeout");
        // Orden fallida!
        GameManager.SINGLETON.OrderCompleted(false, _orderIndex);
		bubble.DisableBubble ();
        
        ResetBehaviourVars();
    }
    
    
    /// <summary>
    /// Resetea las varibles del comportamiento del monje (llamar al terminar comportamientos)
    /// </summary>
    private void ResetBehaviourVars()
    {
        _currentCoroutine = null;
        _currentOrderGO = null;
    }  
    
    #endregion
    
    
    
}
