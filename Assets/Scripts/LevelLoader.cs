using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{    
    public GameObject loadingscreen;
    public Slider slider;

    public void LoadLevel(string a){
       StartCoroutine(LoadAsync(a));
    }

    IEnumerator LoadAsync(string a){
    AsyncOperation operation = SceneManager.LoadSceneAsync(a);
    loadingscreen.SetActive(true);
    while(!operation.isDone){
        float progress = Mathf.Clamp01(operation.progress / .9f);
        slider.value = progress;
        yield return null; 
    }
 }

}
