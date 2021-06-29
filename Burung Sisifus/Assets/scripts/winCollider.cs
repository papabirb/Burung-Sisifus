using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winCollider : MonoBehaviour {

    GameObject gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "egg") {
            gameManager.GetComponent<scoreManagement>().endGame(true);
            Invoke("winGame", 5);
        }
    }

    void winGame() {
        SceneManager.LoadScene(2);
    }
}
