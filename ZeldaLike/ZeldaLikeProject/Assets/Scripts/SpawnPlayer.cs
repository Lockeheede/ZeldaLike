using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject player2;
    public Camera camera2;
    public float xPosition, yPosition;

    void Awake()
    {
        SpawnAPlayer();
    }

    void SpawnAPlayer()
    {
        Vector2 spawnPosition = new Vector2(xPosition, yPosition);
        Instantiate(player2, spawnPosition, Quaternion.identity);
    }
}
