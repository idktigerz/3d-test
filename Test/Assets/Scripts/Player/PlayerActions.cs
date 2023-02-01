using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Unity.VisualScripting;

public class PlayerActions : MonoBehaviour
{
    public GameObject coin;
    public Transform cam;
    public float playerActivateDistance;
    public Text coinText;
    public Text hintText;
    bool active = false;
    int coinCounter = 0;
    private bool canInteract;

    string[] tags = { "Ground", "Wall" };
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "Coins: " + coinCounter;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hintText.enabled);
        RaycastHit hit;
        active = Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, playerActivateDistance);
        if (active && (!hit.collider.CompareTag("Ground") && (!hit.collider.CompareTag("Wall"))))
        {
            hintText.enabled = true;
            Debug.Log("Is active? " + active);
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Catch");
                coin.SetActive(false);
                StartCoroutine(Timer());
                coinCounter++;
                coinText.text = "Coins: " + coinCounter;
            }
        }
        else
        {
            hintText.enabled = false;
            Debug.Log("Is active? " + active);
        }
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            coinCounter++;
            coinText.text = "Coins: " + coinCounter;
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        coin.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shop"))
        {
            canInteract = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shop"))
        {
            canInteract = false;

        }
    }
}
