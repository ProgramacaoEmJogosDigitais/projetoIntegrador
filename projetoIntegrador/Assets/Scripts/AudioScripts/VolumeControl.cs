using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    // Singleton instance
    private static VolumeControl instance;

    // Volume configura��o inicial
    private float volume, volumeEffect;

    // Refer�ncia ao slider no painel de controle de volume
    public Slider musicSlider, effectSlider;

    // Refer�ncia ao objeto canv_options
    public GameObject canvOptions;

    private void Awake()
    {
        // Encontra inst�ncia existente na cena
        instance = FindObjectOfType<VolumeControl>();

        // Se n�o existir uma inst�ncia, esta se torna a inst�ncia �nica
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroi esta inst�ncia se j� existir uma
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Configura o valor inicial do slider
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", volume);
        effectSlider.value = PlayerPrefs.GetFloat("EffectVolume", volume);
        SetVolume(volume); // Configura o volume ao iniciar
        SetVolume(volumeEffect);
    }

    public void SetVolume(float value)
    {
        // Define o volume, salva no PlayerPrefs e atualiza o slider
        volume = value;
        volumeEffect = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.SetFloat("EffectVolume", value);
        AudioListener.volume = volume;
        AudioListener.volume = volumeEffect;
    }

    public void Update()
    {
        FindObjectOfType<Slider>().value = volume;
        FindObjectOfType<Slider>().value = volumeEffect;
        volume = musicSlider.value;
        volumeEffect = effectSlider.value;
    }

    public void LoadOtherScene()
    {
        // Configura o volume ao carregar uma nova cena
        canvOptions.GetComponent<VolumeControl>().SetVolume(volume);
    }
}