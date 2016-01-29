using UnityEngine;
using System.Collections;

public class Monk : MonoBehaviour {

	#region FIELDS
	/// <summary>
	/// Tiempo máximo que estará el monje sin pedir cosas
	/// </summary>
	public int maxTime = 5;

	/// <summary>
	/// Si el monje está pidiendo algo o no
	/// </summary>
	private bool _isAsking = false;
	#endregion

	#region PROPERTIES
	public bool IsAsking { get { return _isAsking; } set { _isAsking = value; } }
	#endregion

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!_isAsking) {
//			GameManager.SINGLETON.GetOrder();
		}
	}
}
