using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    SeletorCharacter tabuleiro;
    private void Start()
    {
        tabuleiro = GameObject.FindObjectOfType<SeletorCharacter>();
    }
    // Update is called once per frame
    void Update()
    {
        //movimento
        if (Input.GetKeyDown(KeyCode.W))
            mover(2.5f, 0);

        if (Input.GetKeyDown(KeyCode.S))
            mover(-2.5f, 0);

        if (Input.GetKeyDown(KeyCode.A))
            mover(0, -1.5f);

        if (Input.GetKeyDown(KeyCode.D))
            mover(0, 1.5f);
    }

    private void mover(float y, float x)
    {
        Vector3 v = transform.localPosition + new Vector3(x, y, 0);
        v.y = Mathf.Clamp(v.y, 0, 4);
        v.x = Mathf.Clamp(v.x, 0, 3);
        transform.localPosition = v;
    }
}
