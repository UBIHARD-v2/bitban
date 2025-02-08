using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    public string state;
    public GameObject succedScreen;
    public GameObject feildScreen;
    public GameObject miniGame;
    public TextMeshProUGUI passwordText;
    public Slider progressBar;
    public TMP_InputField input;
    public float maxTime = 5f;
    public int counter = 0;
    public float remainingtime;
    public string rightPassword;
    // Start is called before the first frame update
    void OnEnable()
    {
        maxTime = 4f;
        maxTime -= 0.75f;
        remainingtime = maxTime;
        RandomStringGenerator();
        input.ActivateInputField();
        input.text = "";
        miniGame.SetActive(true);
        succedScreen.SetActive(false);
        feildScreen.SetActive(false);
        counter = 0;

    }
    private void Update()
    {
        if (counter < 3)
        {
            if (remainingtime > 0)
            {
                remainingtime -= Time.deltaTime;
                progressBar.value = remainingtime / maxTime;
            }
            else
            {
                remainingtime = maxTime;
                // TODO: another password
                Recalculate();
            }
        }else
        {
             miniGame.SetActive(false);
            feildScreen.SetActive(true);   
        }
    }
    void RandomStringGenerator(int stringlength = 5)
    {
        int _stringlength = stringlength - 1;
        string randomstring = "";
        char[] characters = "werasdfzxcv1234#@".ToCharArray();
        for (int i = 0; i <= _stringlength; i++)
        {
            randomstring = randomstring + characters[Random.Range(0, characters.Length - 1)];
        }
        passwordText.text = randomstring;
        rightPassword = randomstring;
    }
    public void Recalculate()
    {

        RandomStringGenerator();
        maxTime += 0.25f;
        remainingtime = maxTime;
        counter++;
        input.text = "";
        input.ActivateInputField();

   
    }

    public void Submit() {
        if (input.text == rightPassword) {
            Succed();
        } else {
            HandleError();
        } 
    }

    private void Succed()
    {
        miniGame.SetActive(false);
        succedScreen.SetActive(true);
        GameObject.Find("GameManager").GetComponent<GameManager>().TurnOffAlarm();

    }

    private void HandleError()
    { 
        if (counter >=3)
        {
            miniGame.SetActive(false);
            feildScreen.SetActive(true);        
        }
        else 
        {
            // TODO: Show error
            Recalculate();
        }
    }

    private void Close() 
    {

    }

    public void OnChange()
    {
        if (rightPassword == input.text) Succed();

    }
    
}
