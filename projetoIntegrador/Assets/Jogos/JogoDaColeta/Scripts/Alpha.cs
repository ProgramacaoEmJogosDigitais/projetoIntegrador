using UnityEngine;

public class Alpha : MonoBehaviour
{
    // Referência ao material do objeto
    private Material material;

    void Start()
    {
        // Obtém o material do objeto (pode ser necessário ter um Renderer no objeto)
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material;

        // Define o alpha para 0.5 (transparência de 50%)
        SetAlpha(0.5f);
    }

    void SetAlpha(float alpha)
    {
        // Garante que o valor de alpha esteja no intervalo [0, 1]
        alpha = Mathf.Clamp01(alpha);

        // Obtém a cor atual do material
        Color corAtual = material.color;

        // Define o novo valor de alpha
        corAtual.a = alpha;

        // Define a nova cor no material
        material.color = corAtual;
    }
}
