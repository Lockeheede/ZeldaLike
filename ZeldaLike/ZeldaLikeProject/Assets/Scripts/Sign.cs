using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    GameObject[] playerArray = new GameObject[2];
    public string dialogue;
    public bool playerInRange;

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            if (Input.GetButtonDown("P1_Interact") || Input.GetButtonDown("P2_Interact"))
                if (dialogueBox.activeInHierarchy)
                {
                    dialogueBox.SetActive(false);
                }
                else
                {
                    dialogueBox.SetActive(true);
                    
                    dialogueText.text = dialogue;
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerArray[0] = other.gameObject;
        }
        if (other.CompareTag("Player2"))
        {
            playerArray[1] = other.gameObject;
        }

        if (playerArray[0] != null || playerArray[1] != null)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerArray[0] = null;
        }
        if (other.CompareTag("Player2"))
        {
            playerArray[1] = null;
        }
        if (playerArray[0] == null || playerArray[1] == null)
        {
            playerInRange = false;
            dialogueBox.SetActive(false);
        }
    }
}
