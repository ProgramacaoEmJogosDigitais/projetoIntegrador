using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectsFalling : MonoBehaviour

{
    void Update()
    {
        if (transform.position.y < -6f)
        {
            // Destrua o objeto que caiu
            Destroy(gameObject);

            // Aumente o número de objetos perdidos do jogador
            PlayerColeta.MissingObject();
        }
    }
}
