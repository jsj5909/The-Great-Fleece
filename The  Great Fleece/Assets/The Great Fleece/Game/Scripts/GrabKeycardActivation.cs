using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeycardActivation : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject _sleepingGuardCutscene;
    [SerializeField] Collider colliderTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            _sleepingGuardCutscene.SetActive(true);

            colliderTrigger.enabled = false;

            GameManager.Instance.HasCard = true;
        }
        
    }

}
