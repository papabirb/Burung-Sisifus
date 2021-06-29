using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class loadHighScores : MonoBehaviour {

    public bool winList = false;
    public Text txt;
    private string leaderboard = "";
    private string losePath = "Assets/scores/lose_highscores.txt";
    private string winPath = "Assets/scores/win_highscores.txt";

    // Use this for initialization
    void Start () {
        txt = gameObject.GetComponent<Text>();
        if (winList)
        {
            readFile(winPath);
        }
        else {
            readFile(losePath);
        }
        txt.text = leaderboard;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void readFile(string path)
    {
        StreamReader sr = new StreamReader(path);
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            leaderboard = leaderboard + line + "\n";
        }
        sr.Close();
    }
}
