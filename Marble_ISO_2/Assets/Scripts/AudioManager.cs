using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("======== Music Source ========")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    
    [Header("======== SFX Source ========")]
    public AudioClip backgroundMusic;
    public AudioClip levelSwap;
    public AudioClip gameOver;
    public AudioClip jumpFX;
    public AudioClip portalIn;
    public AudioClip portalOut;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
