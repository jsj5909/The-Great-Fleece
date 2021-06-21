using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GuardAI : MonoBehaviour
{

    [SerializeField]
    List<Transform> _waypoints;

    Animator _animator;

    NavMeshAgent _agent;

    [SerializeField]
    int _currentTarget = 0;

    bool _reverse = false;

    bool _targetReached = false;

    bool _waiting = false;

    // Start is called before the first frame update
    void Start()
    {

        _animator = GetComponent<Animator>();
        if(_animator == null)
        {
            Debug.LogError("A Guard Animator is null");
        }
        
        _agent = GetComponent<NavMeshAgent>();
        if (_agent == null)
        {
            Debug.LogError("Nav mesh Agent on guard is null");
        }



        if (_waypoints.Count > 0)
        {
            if (_waypoints[_currentTarget] != null)
            {
                _animator.SetBool("Walk", true);
                _agent.SetDestination(_waypoints[_currentTarget].position);
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (_waypoints.Count > 0)
        {

            if (_waypoints[_currentTarget] != null)
            {

                if ((Vector3.Distance(transform.position, _waypoints[_currentTarget].position) < 1) && (_targetReached == false))
                {
                    _targetReached = true;

                   


                    if (_reverse == false)
                    {
                        _currentTarget++;
                    }
                    else
                    {
                        _currentTarget--;
                    }

                    if (_currentTarget >= _waypoints.Count)
                    {
                        _reverse = true;
                        _currentTarget--;
                    }
                    if(_currentTarget < 0)
                    {
                        _reverse = false;
                        _currentTarget++;
                    }
                //    if (_waypoints[_currentTarget] != null)
                //    {
                 //      (if(_wait))
                       
                        
                    //    _agent.SetDestination(_waypoints[_currentTarget].position);
                        
                   // }
                }
                if(_targetReached == true)
                {
                    if (_currentTarget-1 == 0 || (_currentTarget+1 == _waypoints.Count - 1))
                    {
                        if (_waiting == false)
                        {
                            StartCoroutine(WaitBeforeMoving());

                        }
                    }
                    else
                    {
                        _agent.SetDestination(_waypoints[_currentTarget].position);
                        _animator.SetBool("Walk", true);
                        _targetReached = false;

                    }


                }
            }
        }

    }


    IEnumerator WaitBeforeMoving()
    {
        _waiting = true;
        _animator.SetBool("Walk", false);
        float waitTime = Random.Range(2,5);
        yield return new WaitForSeconds(waitTime);
        _waiting = false;
        _targetReached = false;
        _agent.SetDestination(_waypoints[_currentTarget].position);
        _animator.SetBool("Walk", true);
    }
}
