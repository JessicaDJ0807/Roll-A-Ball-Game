using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockControl : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // offset = player.transform.position - transform.position;
        // Debug.Log("Offset: " + offset);
        offset = new Vector3(0.06f, -0.56f, 0.49f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position - offset;
    }
}
