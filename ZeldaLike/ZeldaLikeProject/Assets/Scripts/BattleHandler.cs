using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private Transform Player1;
    [SerializeField] private Transform Player2;

    private void Start()
    {
        Instantiate(Player1, new Vector3(+50, 0), Quaternion.identity);
        Instantiate(Player2, new Vector3(+50, 0), Quaternion.identity);
    }

}
