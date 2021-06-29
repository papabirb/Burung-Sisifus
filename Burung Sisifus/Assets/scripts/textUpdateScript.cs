using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textUpdateScript : MonoBehaviour {

    public Text txt;
    public GameObject gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager");
        txt = gameObject.GetComponent<Text>();
        txt.text = "You Survived " + gameManager.GetComponent<scoreManagement>().lastScore + " Seconds";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
