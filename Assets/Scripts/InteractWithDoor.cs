using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithDoor : MonoBehaviour
{
    public bool open = false;

    private void Update()
    {
        
    }

    public int OpenDoor()
    {
        if(this.open == false) {
            transform.Rotate(0, 90, 0);
            this.open = true;
            StartCoroutine(WaitToScan(0.25f));
            return 0;
        }
        return 1;
    }

    public int CloseDoor()
    {
        if(this.open == true) {
            transform.Rotate(0, -90, 0);
            this.open = false;
            StartCoroutine(WaitToScan(0.25f));
            return 0;
        }
        return 1;
    }

    private IEnumerator WaitToScan(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        AstarPath.active.Scan();
    }
}
