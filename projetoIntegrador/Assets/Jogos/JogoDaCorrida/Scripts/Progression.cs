using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Progression : MonoBehaviour
{
    public float meta;
    public float increaseMeta;
    private MovimentPlayer movimentPlayerScript;
    private ParallaxJCorrida parallaxJCorridaScript;
    private CreateObstacle createobstacleScript;
    public bool atingiuAMeta;

    void Start()
    {
        movimentPlayerScript = FindObjectOfType<MovimentPlayer>();
        parallaxJCorridaScript = FindObjectOfType<ParallaxJCorrida>();
        createobstacleScript = FindObjectOfType<CreateObstacle>();

        atingiuAMeta = false;
    }

    
    void Update()
    {
        if (movimentPlayerScript.distance >= meta)  
        {
            atingiuAMeta = true;
            meta = meta + increaseMeta;
        }

        if (parallaxJCorridaScript.progressParallaxJScript && movimentPlayerScript.progressMovimentPScript && createobstacleScript.progressCreateOScript) 
        {
            parallaxJCorridaScript.progressParallaxJScript = false;
            movimentPlayerScript.progressMovimentPScript = false;
            createobstacleScript.progressCreateOScript = false;
            atingiuAMeta = false;
        }
    }

}