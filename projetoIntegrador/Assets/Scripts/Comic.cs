using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comic : MonoBehaviour
{
    [SerializeField] float pageSpeed = 0.5f;
    [SerializeField] List<Transform> pages;
    int index = -1;
    bool rotate = false;
    public void RotateNext()
    {
        if (rotate == true) { return; }
        index++;
        float angle = 180;
        pages[index].SetAsLastSibling();
        StartCoroutine(Rotate(angle, true));
    }
    public void RotateBack()
    {
        if(rotate == true) {return; }
        float angle = 0;
        pages[index].SetAsFirstSibling();
        StartCoroutine(Rotate(angle, false));
    }
    IEnumerator Rotate(float angle, bool forward)
    {
        float value = 0f;
        while (true)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, angle, 0f);
            value += Time.deltaTime * pageSpeed;
            pages[index].rotation = Quaternion.Slerp(pages[index].rotation, targetRotation, value);
            float angle1 = Quaternion.Angle(pages[index].rotation, targetRotation);

            if(angle < 0.1f)
            {
                if(forward == false)
                {
                    index--;
                }
                rotate = false;
                break;
            }
            yield return null;
        }
    }
}
