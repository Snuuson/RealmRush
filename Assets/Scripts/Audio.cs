using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip notEnoughMinerals;
    [SerializeField] AudioClip BackgroundMusic;
    AudioSource audioSource;
    void Start()
    {
        if (FindObjectsOfType<Audio>().Length > 1)
        {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayNotEnoughMinerals() 
    {

        if (!audioSource.isPlaying) 
        {
            audioSource.PlayOneShot(notEnoughMinerals);
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
