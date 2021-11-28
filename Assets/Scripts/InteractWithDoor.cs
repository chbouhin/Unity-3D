using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithDoor : MonoBehaviour
{
    public bool open;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int OpenDoor()
    {
        if(this.open == false) {
            transform.Rotate(0, 90, 0);
            this.open = true;
            return 0;
        }
        return 1;
    }

    public int CloseDoor()
    {
        if(this.open == true) {
            transform.Rotate(0, -90, 0);
            this.open = false;
            return 0;
        }
        return 1;
    }
}
