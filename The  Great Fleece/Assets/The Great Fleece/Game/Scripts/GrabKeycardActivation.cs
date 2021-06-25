using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeycardActivation : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject _sleepingGuardCutscene;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _sleepingGuardCutscene.SetActive(true);

            GameManager.Instance.HasCard = true;
        }
        else
        {
            Debug.Log("You must grab the keycard");
        }
    }

}
