using TMPro;    
using UnityEngine;

public class BinaryGameManager : MonoBehaviour
{
    public string[] binaries = { 
        "0000-0000",
        "1011-0000",
        "1101-0000",
        "0110-0011",
        "1100-0010",
        "0010-0110"
    };
    public string[] hexes = { 
        "00", "B0", "D0", "63", "C2", "26"
    };

    public TextMeshProUGUI submitted;

    public TextMeshProUGUI binaryText;
    public TMP_InputField hexInput;
    public GameObject gameManager;
    public GameObject errorText;
    void Start()
    {
        binaryText.text = binaries[0];
    }
    int currentIndex = 0;
    public void Submit()
    {
        string input = hexInput.text;
        if (input == hexes[currentIndex])
        {
            NextStep();
        } else
        {
            errorText.SetActive(true);
        }
    }

    void NextStep()
    {
        string suffix = ":";
        if (currentIndex == hexes.Length - 1) suffix = "";
        submitted.text +=  hexes[currentIndex] + suffix;
        
        errorText.SetActive(false);
        if (currentIndex == hexes.Length - 1)
        {
            binaryText.text = "You won";
            gameManager.GetComponent<GameManager>().everythingOK = true;
            gameManager.GetComponent<GameManager>().PlayMoralPand();
            gameManager.GetComponent<GameManager>().TurnOffAlarm();
            return;
        }
        currentIndex++;
        binaryText.text = binaries[currentIndex];
        hexInput.text = "";
    }
}
