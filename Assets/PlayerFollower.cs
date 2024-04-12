using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] GameObject player; //reference player

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //read our position
        Vector3 pos = transform.position;

        //assign position to x position of player
        pos.x = player.transform.position.x;

        //set new x position
        transform.position = pos;
    }
}
