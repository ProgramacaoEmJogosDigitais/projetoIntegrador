using UnityEngine;

public class Alpha : MonoBehaviour
{
    // Refer�ncia ao material do objeto
    private Material material;

    // Vari�veis de controle de pontua��o
    public float pontuacao = 0.0f;
    public float limiteDePontuacao = 50.0f;

    void Start()
    {
        // Obt�m o material do objeto (pode ser necess�rio ter um Renderer no objeto)
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material;

        // Define o alpha para 0.5 (transpar�ncia de 50%)
        SetAlpha(0.5f);
    }

    void Update()
    {
        // Verifica se a pontua��o ultrapassa o limite especificado
        if (FishsFalling.points > limiteDePontuacao)
        {
            // Define o alpha para 1.0 (transpar�ncia de 100%)
            SetAlpha(1.0f);
        }
    }

    void SetAlpha(float alpha)
    {
        // Garante que o valor de alpha esteja no intervalo [0, 1]
        alpha = Mathf.Clamp01(alpha);

        // Obt�m a cor atual do material
        Color corAtual = material.color;

        // Define o novo valor de alpha
        corAtual.a = alpha;

        // Define a nova cor no material
        material.color = corAtual;
    }
}