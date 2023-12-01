using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPosition : MonoBehaviour
{
    private bool hasLoaded = false;

    private void Start()
    {
        if (!hasLoaded && PlayerPrefs.HasKey("ObjectPosX"))
        {
            float posX = PlayerPrefs.GetFloat("ObjectPosX");
            float posY = PlayerPrefs.GetFloat("ObjectPosY");
            float posZ = PlayerPrefs.GetFloat("ObjectPosZ");
            Vector3 savedPosition = new Vector3(posX, posY, posZ);

            GameObject objectToMove = GameObject.FindGameObjectWithTag("Player");

            if (objectToMove != null)
            {
                objectToMove.transform.position = savedPosition;
            }

            hasLoaded = true;
        }
    }

    private void OnDestroy()
    {
        SaveObjectPosition();
    }

    private void SaveObjectPosition()
    {
        GameObject objectToSave = GameObject.FindGameObjectWithTag("Player");

        if (objectToSave != null)
        {
            PlayerPrefs.SetFloat("ObjectPosX", objectToSave.transform.position.x);
            PlayerPrefs.SetFloat("ObjectPosY", objectToSave.transform.position.y);
            PlayerPrefs.SetFloat("ObjectPosZ", objectToSave.transform.position.z);
            PlayerPrefs.Save();
        }
    }
}
