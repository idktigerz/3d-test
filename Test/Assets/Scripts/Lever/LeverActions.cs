using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActions : MonoBehaviour
{
    [SerializeField] Transform playerCam;

    private Material leverColor;

    private bool leverState;
    private bool active;
    private bool canInteract;

    private float playerActivateDistance = 1.5f;
    [SerializeField] wallControler wallControler;
    // Start is called before the first frame update
    void Start()
    {
        leverColor = GetComponent<Renderer>().material;
    }
    void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(playerCam.position, playerCam.TransformDirection(Vector3.forward), out hit, playerActivateDistance);
        if (active && hit.collider.CompareTag("Lever") && Input.GetKeyDown(KeyCode.E))
        {
            if (leverState)
            {
                leverColor.color = Color.green;
                wallControler.MoveGate(leverState);
                leverState = false;
                
            }
            else
            {
                leverColor.color = Color.red;
                wallControler.MoveGate(leverState);
                leverState = true;
            }
        }

    }
}
