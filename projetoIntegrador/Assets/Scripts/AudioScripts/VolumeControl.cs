using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    // Singleton instance
    private static VolumeControl instance;

    // Volume configura��o inicial
    private float volume = 1.0f;
    private float volumeEffect = 1.0f;

    // Refer�ncia ao slider no painel de controle de volume
    public Slider musicSlider;
    public Slider effectSlider;

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
    }

    public void SetVolume(float value)
    {
        // Define o volume, salva no PlayerPrefs e atualiza o slider
        volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.SetFloat("EffectVolume", value);
        AudioListener.volume = volume;
    }

    public void Update()
    {
        FindObjectOfType<Slider>().value = volume;
        FindObjectOfType<Slider>().value = volumeEffect;
    }

    public void LoadOtherScene()
    {
        // Configura o volume ao carregar uma nova cena
        canvOptions.GetComponent<VolumeControl>().SetVolume(volume);
    }
}