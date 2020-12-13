using UnityEngine;
using UnityEngine.SceneManagement;

public class StopScript : MonoBehaviour
{
    public GameObject dark;
    public bool isStop = false;
    public KeyCode stop;

    void Start() { }

    void Update()
    {
        if(Input.GetKeyDown(stop))
        {
            Stop();
        }
    }


    public void Stop()
    {
        isStop = !isStop;
        if (isStop)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        dark.SetActive(isStop);
    }

    public void loadScene(string name)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }
    public void loadScene(int number)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(number);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
