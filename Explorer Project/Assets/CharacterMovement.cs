using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private GameObject Character;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private GameObject model;
    [SerializeField] private GameObject AudioManager;
    private Animator charAnim;
    private bool left, right;
    private AudioManager audioManager;

    void Start()
    {
        // obtain animator and audio manager on first frame of start
        charAnim = Character.GetComponent<Animator>();
        audioManager = AudioManager.GetComponent<AudioManager>();
    }

    void Update()
    {
        // record and update new character position date given some speed
        Vector3 charPosition = Character.transform.position;
        float inputH = Input.GetAxis("Horizontal");
        charPosition.x = charPosition.x + inputH * speed * Time.deltaTime;
        //Debug.Log(charPosition);

        Quaternion charRotation = Character.transform.rotation;
        charRotation = new Quaternion(charRotation.x, charRotation.y, charRotation.z, 1);

        // on right click rotate some
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Debug.Log("mouse pressed");
            model.transform.rotation = charRotation;
        }

        // on clicking 'M' toggle background audio
        if (Input.GetKeyDown(KeyCode.M))
        {
            audioManager.toggleBackgroundAudio();
        }

        // set transition parameters for states
        if (inputH > 0) { left = false; right = true; }
        else if (inputH < 0) { left = true; right = false; }
        else { left = false; right = false; }

        // store values for left and right movement
        charAnim.SetBool("Walking Left", left);
        charAnim.SetBool("Walking Right", right);

        // set new character position to character transform position
        Character.transform.position = charPosition;
        //model.transform.rotation = charRotation;
    }
}
