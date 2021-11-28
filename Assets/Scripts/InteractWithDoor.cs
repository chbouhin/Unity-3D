using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithDoor : MonoBehaviour
{
    bool open;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        OpenDoor()
    }

    int OpenDoor()
    {
        if(open == false) {
            transform.Rotate(0, 90, 0);
            return 0;
        }
        return 1;
    }

    int CloseDoor()
    {
        if(open == true) {
            transform.Rotate(0, -90, 0);
            return 0;
        }
        return 1;
    }
}
