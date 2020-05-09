using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private int gravDir;
    private Jump jump;
    private Rigidbody rigidBody;
    private Vector3 velocity;

    public float speed = 3f;
    public float gravityForce = 9.81f;
    public float pulseStrength = 5f;

    public Image redArrow;
    public Image purpleArrow;
    public Image greenArrow;
    public Image blueArrow;

    public Image powerUp1;
    public Image powerUp2;
    public Image powerUp3;

    private Color havePowerUp1;
    private Color havePowerUp2;
    private Color havePowerUp3;

    private Color fadedPowerUp1;
    private Color fadedPowerUp2;
    private Color fadedPowerUp3;

    private Color highlightedRedArrow;
    private Color highlightedPurpleArrow;
    private Color highlightedGreenArrow;
    private Color highlightedBlueArrow;

    private Color fadedRedArrow;
    private Color fadedPurpleArrow;
    private Color fadedGreenArrow;
    private Color fadedBlueArrow;

    private bool gamePaused = true;

    private int powerUp = 0;
    private AudioClip powerUpSound;
    private AudioSource powerUpSource;
    public GameObject powerUpMaster;

    private AudioClip explosionSound;
    private AudioSource explosionSource;
    private AudioClip winSound;
    private AudioSource winSource;

    private ParticleSystem explodeParticle;
    private ParticleSystem winParticle;

    public bool leftGrav = false, rightGrav = false, upGrav = false, downGrav = false;

    public GameObject UIObject;

    private AudioSource backGroundAudio;

    public GameObject backGround;

    private Vector3 mousePosXYZ;
    private Vector2 playerPosXY;
    private Vector2 mousePosXY;

    private void Start()
    {
        if (gamePaused)
        {
            Time.timeScale = 0;
        }

        jump = GetComponent<Jump>();
        rigidBody = GetComponent<Rigidbody>();
        backGroundAudio = GetComponent<AudioSource>();

        highlightedRedArrow = redArrow.color;
        highlightedPurpleArrow = purpleArrow.color;
        highlightedGreenArrow = greenArrow.color;
        highlightedBlueArrow = blueArrow.color;

        fadedRedArrow = redArrow.color;
        fadedPurpleArrow = purpleArrow.color;
        fadedGreenArrow = greenArrow.color;
        fadedBlueArrow = blueArrow.color;

        fadedRedArrow.a = 0.25f;
        fadedPurpleArrow.a = 0.25f;
        fadedGreenArrow.a = 0.25f;
        fadedBlueArrow.a = 0.25f;

        havePowerUp1 = powerUp1.color;
        havePowerUp2 = powerUp2.color;
        havePowerUp3 = powerUp3.color;

        fadedPowerUp1 = powerUp1.color;
        fadedPowerUp2 = powerUp2.color;
        fadedPowerUp3 = powerUp3.color;

        havePowerUp1.a = 1f;
        havePowerUp2.a = 1f;
        havePowerUp3.a = 1f;

        powerUpSound = Resources.Load<AudioClip>("coin_20");
        powerUpSource = powerUpMaster.GetComponent<AudioSource>();

        explosionSound = Resources.Load<AudioClip>("explosion_19");
        explosionSource = powerUpSource;

        winSound = Resources.Load<AudioClip>("power_up_26");
        winSource = powerUpSource;

        explodeParticle = GetComponent<ParticleSystem>();
        winParticle = explodeParticle;
    }

    private void Update()
    {
        if (gamePaused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                gamePaused = false;
            }
        }

        switch (gravDir)
        {
            case 0:
                jump.DownJump();
                MoveRight();
                break;
            case 1:
                jump.LeftJump();
                MoveUpwards();
                break;
            case 2:
                jump.UpJump();
                MoveRight();
                break;
            case 3:
                jump.RightJump();
                MoveUpwards();
                break;
        }

        GravitySwapUpdate();

        PulsePowerUp();

        PowerUpReceived();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == ("Kill"))
        {
            explodeParticle.Play();
            explosionSource.PlayOneShot(explosionSound);
            Destroy(this.gameObject, 0.2f);

            UIObject.GetComponent<InGameUI>().deathMenu.SetActive(true);
        }

        if (collision.gameObject.tag == ("PowerUp"))
        {
            if (powerUp < 4)
            {
                if(powerUp < 3)
                    powerUp++;
                Destroy(collision.gameObject);
                powerUpSource.PlayOneShot(powerUpSound);
            }
        }

        if(collision.gameObject.tag == ("Win"))
        {
            winParticle.Play();
            winSource.PlayOneShot(winSound);
            rigidBody.isKinematic = true;
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;

            if (backGroundAudio.isPlaying)
                backGroundAudio.Pause();

            UIObject.GetComponent<InGameUI>().winMenu.SetActive(true);
            backGround.SetActive(false);
            UIObject.GetComponent<InGameUI>().success = true;
        }
    }

    private void PowerUpReceived()
    {
        if(powerUp > -1)
        {
            powerUp1.color = fadedPowerUp1;
            powerUp2.color = fadedPowerUp2;
            powerUp3.color = fadedPowerUp3;
            if (powerUp > 0)
                powerUp1.color = havePowerUp1;
                if (powerUp > 1)
                    powerUp2.color = havePowerUp2;
                    if (powerUp > 2)
                        powerUp3.color = havePowerUp3;
        }  
    }

    private void MoveRight()
    {
        velocity = rigidBody.velocity;
        velocity.x = speed;
        rigidBody.velocity = velocity;
    }
    private void MoveUpwards()
    {
        velocity = rigidBody.velocity;
        velocity.y = speed;
        rigidBody.velocity = velocity;
    }

    public void GravitySwapUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || leftGrav)
        {
            Physics.gravity = new Vector2(-gravityForce, 0f);
            gravDir = 3;
            redArrow.color = fadedRedArrow;
            purpleArrow.color = fadedPurpleArrow;
            blueArrow.color = fadedBlueArrow;
            greenArrow.color = highlightedGreenArrow;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || downGrav)
        {
            Physics.gravity = new Vector2(0f, -gravityForce);
            gravDir = 0;
            purpleArrow.color = fadedPurpleArrow;
            greenArrow.color = fadedGreenArrow;
            blueArrow.color = fadedBlueArrow;
            redArrow.color = highlightedRedArrow;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || upGrav)
        {
            Physics.gravity = new Vector2(0f, gravityForce);
            gravDir = 2;
            redArrow.color = fadedRedArrow;
            greenArrow.color = fadedGreenArrow;
            blueArrow.color = fadedBlueArrow;
            purpleArrow.color = highlightedPurpleArrow;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || rightGrav)
        {
            Physics.gravity = new Vector2(gravityForce, 0f);
            gravDir = 1;
            redArrow.color = fadedRedArrow;
            purpleArrow.color = fadedPurpleArrow;
            greenArrow.color = fadedGreenArrow;
            blueArrow.color = highlightedBlueArrow;
        }
    }

    private void PulsePowerUp()
    {
        if (powerUp > 0)
            if (Input.GetMouseButtonDown(0))
            {
                mousePosXYZ = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                playerPosXY = new Vector2(this.transform.position.x, this.transform.position.y);
                mousePosXY = new Vector2(mousePosXYZ.x, mousePosXYZ.y);
                rigidBody.velocity = (mousePosXY - playerPosXY).normalized * pulseStrength;
                powerUp--;
            }
    }

}
