using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour
{
    public Camera Camera1;
    public Camera Camera2;
    // Start is called before the first frame update

    public bool Horizontal = false;



    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeSplitScreen();
        }
    }
    public void ChangeSplitScreen()
    {
        Horizontal = !Horizontal;

        if(Horizontal)
        {
            Camera1.rect = new Rect(0, 0, 1, 0.5f);
            Camera2.rect = new Rect(0, 0, 1, 0.5f);
        }
        else
        {
            Camera1.rect = new Rect(0, 0, 0.5f, 1);
            Camera2.rect = new Rect(0.5f, 0, 0.5f, 1);
        }
    }
}
