using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField] GameObject _gameOverCutScene;

    [SerializeField] Animator _animator;

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
        if (other.gameObject.tag == "Player")
        {
            MeshRenderer mesh = GetComponent<MeshRenderer>();
            Color color = new Color(0.6f, 0.1f, 0.1f, 0.3f);
            mesh.material.SetColor("_TintColor", color);
            
            _animator.enabled = false;

            StartCoroutine(StartCutScene());
        }
    }

    IEnumerator StartCutScene()
    {
        yield return new WaitForSeconds(0.5f);
        _gameOverCutScene.SetActive(true);
    }
}
