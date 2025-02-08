using UnityEngine;

public class Monitor : MonoBehaviour
{
    public GameObject alarmImage;
    public GameObject referencedCanvas;
    
    public void Alert()
    {
        alarmImage.SetActive(true);
    }
    
    public void TurnOff()
    {
        alarmImage.SetActive(false);
    }
}
