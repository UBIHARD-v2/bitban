using TMPro;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject camera;
    public LayerMask layerMask;
    public LayerMask canvasLayerMask;
    public float maxDistance = 20f;
    public GameObject text;
    public GameManager gameManager;
    public GameObject mainCamera;
    public GameObject orginalCameraPos;
    public GameObject rawImage;
    GameObject manitorCanves ;
    private bool doorIsOpen = false;
    void Update()
    {
        RaycastHit raycastHit;
        var raycast = Physics.Raycast(camera.transform.position, camera.transform.forward, out raycastHit, maxDistance, layerMask);

        if (raycast)
        {
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }


        if (raycast && Input.GetKey(KeyCode.E) && raycastHit.transform.gameObject.CompareTag("monitor"))
        {
            var gameObj = raycastHit.transform.GetChild(1).gameObject;
            manitorCanves = raycastHit.transform.gameObject.GetComponent<Monitor>().referencedCanvas;
            manitorCanves.SetActive(true);
            gameManager.SetLockedIn(true);
            GetComponent<PlayerMovement>().enabled = false;
            mainCamera.GetComponent<CameraMove>().SetNewPosition(gameObj);
            mainCamera.GetComponent<CameraMovement>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            rawImage.SetActive(true);
        }
        else if (raycast && Input.GetKeyDown(KeyCode.E) && raycastHit.transform.gameObject.CompareTag("door"))
        {
            doorIsOpen = !doorIsOpen;
            raycastHit.transform.gameObject.GetComponent<door>().animator.SetBool("IsOpen", doorIsOpen);
        }
        if (gameManager.lockedIn && Input.GetKey(KeyCode.Q))
        {
            manitorCanves.SetActive(false);
            mainCamera.GetComponent<CameraMove>().SetNewPosition(orginalCameraPos);
            GetComponent<PlayerMovement>().enabled = true;
            gameManager.SetLockedIn(false);
            mainCamera.GetComponent<CameraMovement>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            rawImage.SetActive(false);

 

        }

        if (gameManager.lockedIn == true) text.GetComponent<TextMeshProUGUI>().text = "Press \"Q\" to quit";
        else text.GetComponent<TextMeshProUGUI>().text = "Press \"E\" to lock in";


        var raycastInteract = Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit raycastHitCanvas, maxDistance, canvasLayerMask);
        if (raycastInteract) 
        {
            if (raycastHitCanvas.collider.CompareTag("TerminalCanvas"))
            {
                Debug.Log("Raycast Interaction");
            }
        }
    }

    // void OnTriggerExit
}
