using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Dictionary<string, int> _inv = new Dictionary<string, int>();

    public void Add(string name, int nb = 1)
    {
        if (_inv.ContainsKey(name))
            _inv[name] += nb;
        else
            _inv.Add(name, nb);
    }

    public int Get(string name)
    {
        return (_inv.ContainsKey(name)) ? _inv[name] : 0;
    }

    public bool Remove(string name, int nb = 1)
    {
        if (_inv.ContainsKey(name)) {
            int nbInInv = _inv[name] - nb;
            if (nbInInv < 0) {
                Debug.Log("Not enough " + name + " in the player inventory");
                return false;
            } else if (nbInInv == 0) {
                _inv.Remove(name);
                return true;
            } else {
                _inv[name] = nbInInv;
                return true;
            }
        } else {
            Debug.Log("No " + name + " in the player inventory");
            return false;
        }
    }
}
