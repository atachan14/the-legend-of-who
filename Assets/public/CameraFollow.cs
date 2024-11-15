using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    //Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position+offset;
    }
}
