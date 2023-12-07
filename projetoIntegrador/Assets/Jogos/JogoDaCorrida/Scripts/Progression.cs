using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Progression : MonoBehaviour
{
    public float meta;
    public float increaseMeta;
    public float multipleSpeed;
    private MovimentPlayer movimentPlayerScript;
    private ParallaxJCorrida parallaxJCorridaScript;
    private Obstacle obstacleScript;
    private CreateObstacle createObstacleScript;
    public bool atingiuAMeta;

    public List<GameObject> objectsGame = new List<GameObject>(); // Lista de obstáculos instanciados


    void Start()
    {
        movimentPlayerScript = FindObjectOfType<MovimentPlayer>();
        parallaxJCorridaScript = FindObjectOfType<ParallaxJCorrida>();
        obstacleScript = FindObjectOfType<Obstacle>();
        createObstacleScript = FindObjectOfType<CreateObstacle>();
        atingiuAMeta = false;
    }

    
    void Update()
    {
        if (movimentPlayerScript.distance >= meta)//TODO: Fazer logica de quando muda velocidade.
        {
            atingiuAMeta = true;
            meta = meta + increaseMeta;
        }
    }

}