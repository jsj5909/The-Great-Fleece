using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//-7.81 0.11 32.83



public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private AudioClip _coinSoundEffect;

    private bool _coinTossed = false;

    NavMeshAgent _agent;

    Animator _animator;

    private Vector3 _target;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
          Vector3 position =  Input.mousePosition;

           Ray rayOrigin = Camera.main.ScreenPointToRay(position);

            RaycastHit hitInfo;

            if(Physics.Raycast(rayOrigin,out hitInfo))
            {
               
               _agent.SetDestination(hitInfo.point);

                _animator.SetBool("Walk", true);

                _target = hitInfo.point;
            }
            

        }
        if (Vector3.Distance(transform.position, _target) < 1)
        {
            _animator.SetBool("Walk", false);
        }

        if(Input.GetMouseButtonDown(1))
        {
            
            
            if (_coinTossed == false)
            {
                _animator.SetTrigger("Throw");

                Vector3 position = Input.mousePosition;

                Ray rayOrigin = Camera.main.ScreenPointToRay(position);

                RaycastHit hitInfo;

                if (Physics.Raycast(rayOrigin, out hitInfo))
                {
                    Instantiate(_coinPrefab, hitInfo.point, Quaternion.identity);

                    AudioSource.PlayClipAtPoint(_coinSoundEffect, transform.position);

                    _coinTossed = true;

                    SendAIToCoin(hitInfo.point);
                   

                }
                
            }
        }

    }

    private void SendAIToCoin(Vector3 location)
    {
        GuardAI[] guards = FindObjectsOfType<GuardAI>();

        foreach (GuardAI guard in guards)
        {
            NavMeshAgent nav = guard.GetComponent<NavMeshAgent>();
            nav.SetDestination(location);
            guard.movingToCoin = true;
            guard.coinLocation = location;
            guard.StartWalking();
        }
            
    }
}
