using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    GameObject _player;

   
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");

        if(_player == null)
        {
            Debug.LogError("Player is Null");
        }

       

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player.transform);
    }
}
