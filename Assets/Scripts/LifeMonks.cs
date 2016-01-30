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
	private GameObject[] _lifeMonks;
	private bool[] _happyMonks;

	/// <summary>
	/// Número de monjes que no te miran
	/// </summary>
	private int _numHappyMonks;

	/// <summary>
	/// Número de monjes que sí te miran
	/// </summary>
	private int _numAngryMonks;
	#endregion

	#region UNITY
	// Use this for initialization
	void Start () {
		_lifeMonks = GameObject.FindGameObjectsWithTag("LifeMonk");
		_numHappyMonks = GameManager.SINGLETON.life;
		_numAngryMonks = 0;

		_happyMonks = new bool[_numHappyMonks];
		for (int i=0; i<_happyMonks.Length; i++)
			_happyMonks[i] = true;
	}
	
	// Update is called once per frame
	void Update () {}
	#endregion

	#region METHODS
	/// <summary>
	/// Si pierdes una vida un monje random mira a la cámara
	/// </summary>
	public void LifeLost() {
		//Elegimos un monje feliz random para ponerlo enfadado
		int index = Random.Range (0, _numHappyMonks);
		int count = 0;

		//Buscamos al monje que hemos elegido y hacemos que mire a cámara
		for (int i=0; i<_lifeMonks.Length; i++) {
			if (_happyMonks[i] == true) {
				if (count == index) {
					_happyMonks[i] = false;
					_lifeMonks[i].GetComponent<SpriteRenderer>().color = Color.red;
					break;
				}
				count++;
			}
		}

		//Ahora hay un monje enfadado más y un monje feliz menos
		_numAngryMonks++;
		_numHappyMonks--;
	}


	/// <summary>
	/// Si ganas una vida un monje random deja de mirar a la cámara
	/// </summary>
	public void LifeGained() {
		//Elegimos un monje enfadado random para ponerlo feliz
		int index = Random.Range (0, _numAngryMonks);
		int count = 0;

		//Buscamos al monje que hemos elegido y hacemos que mire palante
		for (int i=0; i<_lifeMonks.Length; i++) {
			if (_happyMonks[i] == false) {
				if (count == index) {
					_happyMonks[i] = true;
					_lifeMonks[i].GetComponent<SpriteRenderer>().color = Color.white;
					break;
				}
				count++;
			}
		}

		//Ahora hay un monje feliz más y un monje enfadado menos
		_numHappyMonks++;
		_numAngryMonks--;
	}
	#endregion
}
