using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioSystem : MonoBehaviour
{
    public static AudioSystem instance;

    public AudioClip musicMainMenu;
    public AudioClip musicMap;
    public AudioClip jumpSound;
    public AudioClip footstepsSound;

    private AudioSource musicSource;
    private AudioSource sfxSource;

    public List <AudioSource> musicList;
    public List<AudioSource> effectList;
    public List <AudioClip> musicListClip;
    public List <AudioClip> effectListClip;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            // AudioSource para músicas
            musicSource = gameObject.AddComponent<AudioSource>();

            // AudioSource para efeitos sonoros
            sfxSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void Update()
    {
        if (PlayerColeta.playerSpeed > 0f)
        {
            sfxSource.PlayOneShot(footstepsSound);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Audios específicos da cena
        if (scene.name == "MainMenu")
        {
            PlayMusic(musicMainMenu);
        }
        else if (scene.name == "Map")
        {
            PlayMusic(musicMap);
        }
    }

    // Método para reproduzir música de fundo
    void PlayMusic(AudioClip musicClip)
    {
        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.Play();
    }

    // Métodos para reproduzir efeitos sonoros específicos
    public void PlayJumpSound()
    {
        sfxSource.PlayOneShot(jumpSound);
    }

    public void PlayFootstepsSound()
    {
        sfxSource.PlayOneShot(footstepsSound);
    }
}