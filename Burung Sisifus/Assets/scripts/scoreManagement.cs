using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;
using UnityEngine.SceneManagement;

public class scoreManagement : MonoBehaviour {

    public List<float> loseScores;
    public List<float> winScores;
    private string losePath = "Assets/scores/lose_highscores.txt";
    private string winPath = "Assets/scores/win_highscores.txt";
    private bool isGameplay = false;
    public bool gameOver = false;
    public float timeSpent = 0f;
    public string score;
    public string lastScore;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        readFile(winScores, winPath);
        readFile(loseScores, losePath);
	}
	
	// Update is called once per frame
	void Update () {
        if (!isGameplay) {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.buildIndex == 1) {
                isGameplay = true;
                gameOver = false;
                score = "0.0";
            }
        }
        if (isGameplay) {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.buildIndex != 1)
            {
                isGameplay = false;
                Cursor.lockState = CursorLockMode.None;
                StartCoroutine("SlowlyWriteScores");
            }
            else if(!gameOver) {
                timeSpent += Time.deltaTime;
                score = timeSpent.ToString("N4");
                lastScore = score;
            }
        }
	}

    IEnumerator SlowlyWriteScores() {
        yield return new WaitForSeconds(1);
        writeFile(winScores, winPath);
        writeFile(loseScores, losePath);
        yield break;
    }

    public void endGame(bool winState) {
        gameOver = true;
        if (winState)
        {
            winScores.Add(timeSpent);
            winScores.Sort();
        }
        else if (!winState) {
            loseScores.Add(timeSpent);
            loseScores.Sort();
            loseScores.Reverse();
        }
        timeSpent = 0f;
    }

    private void writeFile(List<float> n, string path){
        StreamWriter w = new StreamWriter(path);

        foreach (float a in n) {
            w.Write(a + "\n");
        }

        w.Close();

        AssetDatabase.ImportAsset(path);
    }

    private void readFile(List<float> n, string path) {
        StreamReader sr = new StreamReader(path);
        string line;
        while ((line = sr.ReadLine()) != null){
            float num = float.Parse(line);
            n.Add(num);
        }
        sr.Close();
    }
}
