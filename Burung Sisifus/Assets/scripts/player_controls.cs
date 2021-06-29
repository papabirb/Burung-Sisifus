using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controls : MonoBehaviour {

    Rigidbody rb;
    public int moveStrength = 50;
    public int jumpStrength = 750;
    Vector2 rotate = Vector2.zero;
    public float camSpeed = 3;

    GameObject gameManager;
    AudioSource audio, audioWings;
    public AudioClip collide;
    public AudioClip[] wingFlaps;
    private string score;

    // Use this for initialization
    void Start () {
        rb = gameObject.AddComponent<Rigidbody>() as Rigidbody;
        rb.mass = 7;
        rb.drag = 0.25f;
        rb.angularDrag = 5;
        rb.useGravity = true;

        Cursor.lockState = CursorLockMode.Locked;

        gameManager = GameObject.Find("GameManager");

        audio = gameObject.AddComponent<AudioSource>() as AudioSource;
        audioWings = gameObject.AddComponent<AudioSource>() as AudioSource;
    }
	
	// Update is called once per frame
	void Update () {
        Movement();
        score = gameManager.GetComponent<scoreManagement>().score;
    }

    void Movement() {
        // Move forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveStrength);
            //rb.AddForce(Vector3.forward * moveStrength);
        }
        // Move left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveStrength);
            //rb.AddForce(Vector3.left * moveStrength);
        }
        // Move back
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveStrength);
            //rb.AddForce(Vector3.back * moveStrength);
        }
        // Move right
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveStrength);
            //rb.AddForce(Vector3.right * moveStrength);
        }
        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpStrength);
            int flap = Random.Range(0, wingFlaps.Length);
            audioWings.clip = wingFlaps[flap];
            audioWings.pitch = (Random.Range(0.7f, 1.3f));
            audioWings.Play();
        }
        // Camera
        rotate.y += Input.GetAxis("Mouse X");
        rotate.x -= Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotate * camSpeed;
    }

    void OnGUI() {
        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = 50;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect((Screen.width/2 - 25), 10, 25, 100), score, guiStyle);
    }

    void OnCollisionEnter (Collision other) {
        if (other.gameObject.tag == "egg") {
            audio.clip = collide;
            audio.pitch = (Random.Range(0.1f, 1.5f));
            audio.Play();
        }
    }
}
