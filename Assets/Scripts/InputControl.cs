using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    private BasicShot basicShot;
    private GridShot gridShot;
    // Start is called before the first frame update
    void Start()
    {
        basicShot = GetComponent<BasicShot>();
        gridShot = GetComponent<GridShot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            basicShot.fire();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            gridShot.fire();
        }
    }
}
