using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LifeMonks : MonoBehaviour {

	#region FIELDS
	/// <summary>
	/// Lista con los "monjes de vida"
	/// True -> No mira a cámara (feliz)
	/// False -> Mira a cámara (enfadado)
	/// </summary>
	private List<bool> _lifeMonks;

	/// <summary>
	/// Número de monjes que no te miran
	/// </summary>
	private int _happyMonks;

	/// <summary>
	/// Número de monjes que sí te miran
	/// </summary>
	private int _angryMonks;
	#endregion

	#region UNITY
	// Use this for initialization
	void Start () {
		_lifeMonks = new List<bool>(GameManager.SINGLETON.life);
		_happyMonks = GameManager.SINGLETON.life;
		_angryMonks = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	#endregion

	#region METHODS
	/// <summary>
	/// Si pierdes una vida un monje random mira a la cámara
	/// </summary>
	public void LifeLost() {
		//Elegimos un monje feliz random para ponerlo enfadado
		int index = Random.Range (0, _happyMonks);
		int count = 0;

		//Buscamos al monje que hemos elegido y hacemos que mire a cámara
		for (int i=0; i<_lifeMonks.Count; i++) {
			if (_lifeMonks[i] == true) {
				if (count == index) {
					//TODO Turn Around
					break;
				}
				count++;
			}
		}

		//Ahora hay un monje enfadado más y un monje feliz menos
		_angryMonks++;
		_happyMonks--;
	}


	/// <summary>
	/// Si ganas una vida un monje random deja de mirar a la cámara
	/// </summary>
	public void LifeGained() {
		//Elegimos un monje enfadado random para ponerlo feliz
		int index = Random.Range (0, _angryMonks);
		int count = 0;

		//Buscamos al monje que hemos elegido y hacemos que mire palante
		for (int i=0; i<_lifeMonks.Count; i++) {
			if (_lifeMonks[i] == false) {
				if (count == index) {
					//TODO Turn Around
					break;
				}
				count++;
			}
		}

		//Ahora hay un monje feliz más y un monje enfadado menos
		_happyMonks++;
		_angryMonks--;
	}
	#endregion

	#region SINGLETON
	// Unica instancia de la clase
	private static GameManager _instance = null;

	/// <summary>
	/// Propiedad para acceder al singleton
	/// </summary>
	public static GameManager SINGLETON {
		get {
			if (_instance == null)
				Debug.LogError("ERROR OMG!!!");
			return _instance;
		}
	}
	#endregion
}
