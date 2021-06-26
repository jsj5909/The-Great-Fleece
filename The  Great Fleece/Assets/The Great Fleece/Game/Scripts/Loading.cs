using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Loading : MonoBehaviour
{
    [SerializeField] Image _progressBar;
    
    
    void Start()
    {
        StartCoroutine(LoadMainScene());
    }

    
    IEnumerator LoadMainScene()
    {
        AsyncOperation asynchOperation = SceneManager.LoadSceneAsync(2);
        
        while (!asynchOperation.isDone)
        {
            _progressBar.fillAmount = asynchOperation.progress;

            yield return new WaitForEndOfFrame();
        }

       
    }
}
