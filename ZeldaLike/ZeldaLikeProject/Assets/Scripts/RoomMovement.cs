using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMovement : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    public CameraMovement cam;
    public CameraMovement cam2;
    GameObject[] playerArray = new GameObject[2];
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

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
        if (playerArray[0] != null && playerArray[1] != null)
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            playerArray[0].transform.position += playerChange;

            cam2.minPosition += cameraChange;
            cam2.maxPosition += cameraChange;
            playerArray[1].transform.position += playerChange;

            if (needText)
            {
                StartCoroutine(placeNameCo());
            }
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
    }

    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4);
        text.SetActive(false);
    }

}
