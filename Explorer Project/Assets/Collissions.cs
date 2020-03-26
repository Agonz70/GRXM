using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Collissions : MonoBehaviour
{

    public Text score;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject.transform.parent);
    }

    void OnTriggerEnter2D(Collider2D objectHit)
    {
        Debug.Log("Test");

        // Player collides with object with tag interactable, 
        if(objectHit.gameObject.tag == "Interactable")
        {
            Debug.Log("Health Points ++Score++");
            Destroy(objectHit.gameObject);
        }

        // Player collides with object with tag kill, gets destroyed, and scene restarts
        if (objectHit.gameObject.tag == "Kill")
        {
            Debug.Log("Death!!!~");
            Destroy(gameObject, 0.5f);
            SceneManager.LoadScene("Explorer Project");
        }
            

    }
}
