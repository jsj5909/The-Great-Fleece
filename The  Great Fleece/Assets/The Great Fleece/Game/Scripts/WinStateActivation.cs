using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{

    [SerializeField] GameObject _winCutScene;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(GameManager.Instance.HasCard == true)
            {
                _winCutScene.SetActive(true);
            }
            else
            {
                Debug.Log("You must grab the keycard");
            }
        }
    }

}
