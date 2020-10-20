using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithMachine : MonoBehaviour
{

    public string VendingTag;

    WindowController windows;
    MachineBehaviour machine;
    Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
        windows = GameObject.FindObjectOfType<WindowController>();
        machine = GameObject.FindObjectOfType<MachineBehaviour>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            windows.SwitchWindow();
        }
    }

    void FixedUpdate()
    {
        Ray rayban = mainCam.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(rayban, out RaycastHit hitInfo, Mathf.Infinity);
        
        if(hitInfo.collider != null)
        {

            if (hitInfo.collider.CompareTag(VendingTag))
            {
                if (Input.GetMouseButtonUp(0))
                {
                    machine.BuyRefri();
                }
            }
        }
    }
}
