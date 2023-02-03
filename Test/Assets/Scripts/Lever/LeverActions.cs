using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverActions : MonoBehaviour
{
    [SerializeField] Transform playerCam;
    [SerializeField] Transform Wall;

    private Material leverColor;

    private bool leverState;
    private bool active;
    private bool canInteract;

    private float playerActivateDistance = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        leverColor = GetComponent<Renderer>().material;
        leverState = false;
    }
    void Update()
    {
        RaycastHit hit;
        active = Physics.Raycast(playerCam.position, playerCam.TransformDirection(Vector3.forward), out hit, playerActivateDistance);
        if (active && hit.collider.CompareTag("Lever"))
        {
            canInteract = true;
            if (Input.GetKeyDown(KeyCode.E) && canInteract)
            {
                Debug.Log(leverState);
                if (leverState)
                {
                    leverColor.color = Color.green;
                    Vector3.MoveTowards(Wall.position, new Vector3(-4.6595f, 4.05f, -7.7079f), 10 * Time.deltaTime);
                    leverState = false;
                    Debug.Log(leverState);
                }
                else
                {
                    leverColor.color = Color.red;
                    Vector3.MoveTowards(Wall.position, new Vector3(-4.6595f, 0, -7.7079f), 10 * Time.deltaTime);
                    leverState = true;
                    Debug.Log(leverState);
                }
            }
            canInteract = false;
        }
    }
}
