using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScripts : MonoBehaviour {


    GameObject gameManager;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("GameManager");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void gamePlay() {
        SceneManager.LoadScene(1);
    }

    public void exitGame() {
        Application.Quit();
    }

    public void highScores() {
        SceneManager.LoadScene(4);
    }

    public void mainMenu() {
        Destroy(gameManager);
        SceneManager.LoadScene(0);
    }
}
