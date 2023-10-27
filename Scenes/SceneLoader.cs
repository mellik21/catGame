using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string scenename;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //  if (collision.gettag == player)
        //{
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
        //  }
    }
}
