using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    [SerializeField] float delayTime = 2f;
    [SerializeField] AudioClip successSound;

    AudioSource audioSource;

    bool isTransitioning = false;
    bool collisionDisable = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        string collides = other.gameObject.tag;
        if (isTransitioning == true || collisionDisable == true) { return; }
        switch (collides)
        {
            case "EndDoor":
                StartingNextSequence();
                break;
            default:
                break;
        }
    }


    void StartingNextSequence()
    {
        Debug.Log("Hello");
        isTransitioning = true;
        Invoke("LoadNextLevel", delayTime);
        GetComponent<PlayerController>().enabled = false;

    }

    void LoadNextLevel()
    {
        Debug.Log("You've finished this level!!");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentScene + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }


}
