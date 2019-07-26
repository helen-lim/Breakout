using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Playable at 16:9, 1920 x 1080
    /*
     * TO-DO
     * Make cursor disappear when in game screen
     * Reappear when not in game screen or press esc
     */

    private Vector3 mousePos;
    private Vector3 objectPos;

    public GameObject uiObject;
    private UIController uiController;
    private bool isStart;

    // Start is called before the first frame update
    void Start()
    {

        uiController = uiObject.GetComponent<UIController>();
        mousePos = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        // The game has started
        isStart = uiController.IsStart();

        if (isStart)
        {

            objectPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20f));
            transform.position = new Vector3(Mathf.Clamp(objectPos.x, -17f, 17f), -7.5f, 10f);

            // Be able to exit the screen when escape is pressed
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Cursor.lockState == CursorLockMode.Confined)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
            // When clicked inside game window, keep mouse contained
            else if (Input.GetMouseButtonDown(0))
            {
                if (Cursor.lockState == CursorLockMode.None)
                {
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = false;
                }
            }
        }
        
    }
}
