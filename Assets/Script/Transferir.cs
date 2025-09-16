using System;
using System.Collections;
using System.Linq;
using UnityEditor.SearchService;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transferir : MonoBehaviour
{
    public Animator anim;

    public void Transition(String sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }
    IEnumerator LoadScene(String sceneName)
    {
        anim.SetTrigger("start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }
}
