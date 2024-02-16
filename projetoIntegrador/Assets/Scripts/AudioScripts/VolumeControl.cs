using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    // Singleton instance
    private static VolumeControl instance;

    // Volume configuração inicial
    private float volume, volumeEffect;

    // Referência ao slider no painel de controle de volume
    public Slider musicSlider, effectSlider;

    // Referência ao objeto canv_options
    public GameObject canvOptions;

    private void Awake()
    {
        // Encontra instância existente na cena
        instance = FindObjectOfType<VolumeControl>();

        // Se não existir uma instância, esta se torna a instância única
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroi esta instância se já existir uma
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