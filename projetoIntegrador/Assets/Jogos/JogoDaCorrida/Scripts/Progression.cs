using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Progression : MonoBehaviour
{
    public float meta = 50;
    public float multipleSpeed;
    private MovimentPlayer movimentPlayerScript;
    private ParallaxJCorrida parallaxJCorridaScript;
    private Obstacle obstacleScript;
    private CreateObstacle createObstacleScript;
    public bool atingiuAMeta;

    void Start()
    {
        movimentPlayerScript = FindObjectOfType<MovimentPlayer>();
        parallaxJCorridaScript = FindObjectOfType<ParallaxJCorrida>();
        obstacleScript = FindObjectOfType<Obstacle>();
        createObstacleScript = FindObjectOfType<CreateObstacle>();
        atingiuAMeta = false;
    }
    /*
    void Update()
    {
        if (movimentPlayerScript.distance >= meta)
        {
            AcelerarCorrida();
        }
    }
    
    void AcelerarCorrida()
    {
        atingiuAMeta = true;
        meta += 100; Debug.Log("META:" + meta);
        //parallaxJCorridaScript.objectSpeed *= newSpeed; Debug.Log("OBJECT SPEED: "+parallaxJCorridaScript.objectSpeed);
        movimentPlayerScript.speedPoints *= multipleSpeed; Debug.Log("SPEED POINTS: " + movimentPlayerScript.speedPoints);
        //obstacleScript.sideVelocity *= newSpeed; Debug.Log("OBSTACULO SPEED: " +obstacleScript.sideVelocity);
        createObstacleScript.maxTime -= 0.1f; Debug.Log("max time: " + createObstacleScript.maxTime);
    }**/
}