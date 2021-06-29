using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loseCollider : MonoBehaviour {

    public GameObject jawBone;
    public bool isCroc;
    public AudioClip sound;
    AudioSource audio;
    GameObject gameManager;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        audio = gameObject.AddComponent<AudioSource>() as AudioSource;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "egg" || (isCroc && other.tag == "Player"))
        {
            gameManager.GetComponent<scoreManagement>().endGame(false);
            Invoke("loseGame", 5);
            if (isCroc) { jawBone.transform.Rotate(new Vector3(40, 0, 0)); }
            loseSound();
        }
    }

    void loseGame()
    {
        SceneManager.LoadScene(3);
    }

    void loseSound() {
        audio.PlayOneShot(sound, 1f);
    }
}
