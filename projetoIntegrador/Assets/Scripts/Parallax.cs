using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    public float paraxSpeed;
    public float ParaxLength;
    private Vector2 paraxPosition;


    // Start is called before the first frame update
    void Start()
    {
        ParallaxGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ParallaxGame()
    {
        paraxPosition = transform.position;
        ParaxLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    public void ParallaxScene()
    {
        /*
        using UnityEngine;

public class Parallax : MonoBehaviour
    {

        public float speed; // Speed of the parallax effect
        private float length; // Length of the sprite
        private Vector2 startPos; // Starting position of the sprite

        // Start is called before the first frame update
        void Start()
        {
            startPos = transform.position;
            length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        // Update is called once per frame
        void Update()
        {
            float temp = (Camera.main.transform.position.x * (1 - speed));
            float dist = (Camera.main.transform.position.x * speed);

            transform.position = new Vector3(startPos.x + dist, transform.position.y, transform.position.z);

            if (temp > startPos.x + length) startPos.x += length;
            else if (temp < startPos.x - length) startPos.x -= length;
        }
    }
        */
}
}
