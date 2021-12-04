using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider other)
    {
        string t = other.gameObject.tag;
        Debug.Log ("É^ÉOÇÕ" + t);
        if (t == "CoinTag" || t == "CarTag" || t == "TrafficConeTag")
        {
            Destroy (other.gameObject);
            Debug.Log ("destroyÇµÇ‹ÇµÇΩÅB");
        }
    }

}
