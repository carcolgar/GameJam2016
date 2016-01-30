using UnityEngine;
using System.Collections;

public class ObjectOutlineTest : MonoBehaviour {
    public ObjectOutline outline;
    public bool en = false;
    
    private bool prevState = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	   if (en != prevState) {
           if (en) outline.EnableOutline();
           else outline.DisableOutline();
           prevState = en;
       }
	}
}
