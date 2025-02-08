using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator cameraAnim;
    public GameObject cameraPosition;
    public bool lockedIn = false;
    public GameObject alarmText;
    public float timer;
    public float startTimer; 
    private bool canAlert;
    public GameObject alarmSound;
    public GameObject[] wallMonitors;
    public GameObject[] miniGames;
    public GameObject bitSpawner;

    public GameObject[] lampsOject;

    public GameObject warningLighting;
    public GameObject normalLighting;
    public Material normalLamps;
    public Material warningLamps;
    public GameObject flash;
    public GameObject introduction;
    public bool everythingOK= false;
    public GameObject moralPand;

    private bool alertCkeck = false;


    void Start()
    {
        timer = startTimer;


    }

    void Update() 
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        } else 
        {
            canAlert = true;

        }
        if (!canAlert)
        return;
        if (everythingOK) return;
        Alert();
        canAlert = false;          
    }

    public void Alert()
    {
        cameraAnim.SetTrigger("shake");
        if (!alertCkeck)
        {
            alarmSound.SetActive(true);
            introduction.SetActive(true);
            var desierdMaterials = lampsOject[0].GetComponent<MeshRenderer>().materials;
            lampsOject[0].GetComponent<MeshRenderer>().materials = desierdMaterials;
            lampsOject[1].GetComponent<MeshRenderer>().materials = desierdMaterials;
            normalLighting.SetActive(false);
            alertCkeck = true;
            Invoke("turningOnRedLights",0.5f);

            miniGames[0].SetActive(true);
            for (int i = 0; i < wallMonitors.Length; i++)
            {
                wallMonitors[i].GetComponent<Monitor>().Alert();
            }
            startTimer = Random.Range(2, 10);
            flash.SetActive(true);
        }
    }
    public void turningOnRedLights()
    {
        warningLighting.SetActive(true);
        lampsOject[0].SetActive(true);
        lampsOject[1].SetActive(true);
        var desierdMaterials = lampsOject[0].GetComponent<MeshRenderer>().materials;
        desierdMaterials[1] = warningLamps; 
        lampsOject[0].GetComponent<MeshRenderer>().materials = desierdMaterials;
        lampsOject[1].GetComponent<MeshRenderer>().materials = desierdMaterials;
    }

    public void PlayMoralPand()
    {
        moralPand.SetActive(true);
    }

    
    public void TurnOffAlarm()
    {
        warningLighting.SetActive(false);
        normalLighting.SetActive(true);


        lampsOject[0].SetActive(true);
        lampsOject[1].SetActive(true);
        var desierdMaterials = lampsOject[0].GetComponent<MeshRenderer>().materials;
        desierdMaterials[1] = normalLamps; 
        lampsOject[0].GetComponent<MeshRenderer>().materials = desierdMaterials;
        lampsOject[1].GetComponent<MeshRenderer>().materials = desierdMaterials;
        alertCkeck = false;

        timer = startTimer + 4;
        canAlert = false;
        Debug.Log("pp");
        Invoke("DelayTurningOff",0.5f);
        SetAlarmSound(false);
        bitSpawner.GetComponent<BitSpawner>().Spawn();
        bitSpawner.GetComponent<BitSpawner>().Spawn();
        bitSpawner.GetComponent<BitSpawner>().Spawn();
        for (int i = 0; i < wallMonitors.Length; i++)
        {
            wallMonitors[i].GetComponent<Monitor>().TurnOff();
        }
        flash.SetActive(false);
    }
    void DelayTurningOff()
    {
        miniGames[0].SetActive(false);
    }

    void SetAlarmText(bool state) {
        alarmText.SetActive(state);
    }

    void SetAlarmSound(bool state) 
    {
        alarmSound.SetActive(state);
    }

    public void SetCameraPos(GameObject cameraPos)
    {
        this.cameraPosition = cameraPos;

    }
    public void SetLockedIn(bool value)
    {
        this.lockedIn = value;
    }
}
