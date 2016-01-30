using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    #region FIELDS
    
    /// <summary>
    /// Objeto que sobre el que esta el raton en cada momento
    /// </summary>
    private GameObject _currentHoverObject = null;
    
    #endregion
    
    
    #region UNITY_METHODS
    
    /// <summary>
    /// Update del componente
    /// </summary>
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null) {
                Debug.Log("LeftClicked: "+hit.collider.gameObject.name);
                // TODO: Llamar a quien le importe CLICK IZQUIERDO
            }            
        }
        
        if (Input.GetMouseButtonDown(1))
        {            
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null) {
                Debug.Log("RightClicked: "+hit.collider.gameObject.name);
                // TODO: Llamar a quien le importe CLICK DERECHO
            }            
        }
    }  
    
    /// <summary>
    /// FixedUpdate del componente
    /// </summary>
    private void FixedUpdate()
    {        
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null){
            if(_currentHoverObject!=hit.collider.gameObject) {
                _currentHoverObject = hit.collider.gameObject;
                Debug.Log("HoverBegin: "+_currentHoverObject.name);
                // TODO: Llamar a quien le importe HoverBEGIN
                _currentHoverObject.SendMessage("EnableOutline");
            }
        }
        else
        {
            if(_currentHoverObject != null){
                // TODO: Llamar a quien le importe HoverEND
                _currentHoverObject.SendMessage("DisableOutline");                
                Debug.Log("HoverEnd: "+_currentHoverObject.name);
                _currentHoverObject = null;                
            }
        }            
    } 
    
    #endregion
	
}
