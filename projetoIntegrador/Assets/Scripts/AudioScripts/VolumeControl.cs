using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    // Singleton instance
    private static VolumeControl instance;

    // Volume configuração inicial (pode ser ajustado no Editor Unity)
    private float volume = 1.0f;

    // Referência ao slider no painel de controle de volume
    public Slider musicSlider;
    public Slider effectSlider;

    private void Awake()
    {
        // Garante que só existe uma instância deste objeto
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Configura o valor inicial do slider
        musicSlider.value = volume;
        effectSlider.value = volume;
    }

    public void SetVolume(float value)
    {
        // Define o volume e atualiza o slider
        volume = value;
        AudioListener.volume = volume;
    }
}