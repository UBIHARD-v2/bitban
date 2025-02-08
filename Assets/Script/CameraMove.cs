using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameManager gameManager;
    public Transform cameraPos;
    void Update()
    {
        if (!gameManager.lockedIn)
        {
            transform.position = cameraPos.transform.position;
        }
    }
    public void SetNewPosition(GameObject reference)
    {
        
        transform.position = reference.transform.position;

        transform.rotation = reference.transform.rotation ;
    }
    
}
