using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CanvasButtons : MonoBehaviour
{
    public Sprite musicOn, musicOff;

    private void Start()
    {
        if (PlayerPrefs.GetString("music") == "No" && gameObject.name == "Sound")
        {
            GetComponent<Image>().sprite = musicOff;
        }
    }
    public void RestartGame()
    {
        if (PlayerPrefs.GetString("music") == "Yes")
        {
            GetComponent<AudioSource>().Play();
            StartCoroutine(RestartGameIE());
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //перезагружаем активную сцену, не привязывая к индексу
        }

        IEnumerator RestartGameIE()
        {
            yield return new WaitForSeconds(0.3f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //перезагружаем активную сцену, не привязывая к индексу
        }
    }

    public void LoadInstagram()
    {
        if (PlayerPrefs.GetString("music") == "Yes")
            GetComponent<AudioSource>().Play();

        Application.OpenURL("https://www.instagram.com/hidalgosmill/");
    }

    public void LoadShop()
    {
        if (PlayerPrefs.GetString("music") == "Yes")
            GetComponent<AudioSource>().Play();
        else
        {
            SceneManager.LoadScene(SceneManager.GetSceneByName("Shop").buildIndex);
        }
    }
    public void CloseShop()
    {
        if (PlayerPrefs.GetString("music") == "Yes")
            GetComponent<AudioSource>().Play();
        else
        {
            SceneManager.LoadScene(SceneManager.GetSceneByName("Shop").buildIndex);
        }
    }

    public void MusicWork()
    { 
        if(PlayerPrefs.GetString("music") == "No")
        {
            PlayerPrefs.SetString("music", "Yes");
            GetComponent<Image>().sprite = musicOn;
        } 
        else
        {
            PlayerPrefs.SetString("music", "No");
            GetComponent<Image>().sprite = musicOff;
        }
        if (PlayerPrefs.GetString("music") == "Yes")
            GetComponent<AudioSource>().Play();
    }
}
