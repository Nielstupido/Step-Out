using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    public CanvasGroup bg;
    public CanvasGroup text1;
    public CanvasGroup text2;
    public CanvasGroup text3;
    public CanvasGroup text4;
    public GameObject continueB;
    public int done = 0;
    private int counter = 0;


    void Start()
    {
        bg.LeanAlpha(0, 6.1f).setOnComplete(ContinueEnd);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && done == 1)
        {
            continueB.SetActive(false);
            text1.LeanAlpha(0, .5f).delay = .2f;
            text2.LeanAlpha(0, .5f).setOnComplete(ContinueEnd);
            text3.LeanAlpha(1, .5f).delay = 1.1f;
            text4.LeanAlpha(1, .5f).delay = 1.1f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && done == 2)
        {
            continueB.SetActive(false);
            bg.gameObject.SetActive(true);
            StartCoroutine(FadeAudio(gameObject.GetComponent<AudioSource>(), 2f, 0f));
            bg.LeanAlpha(1, 2f).setOnComplete(CompleteGame).delay = .2f;
        }
    }

    void ContinueEnd()
    {
        bg.gameObject.SetActive(false);
        Invoke("ShowContinueButton", 10f);
    }


    void ShowContinueButton()
    {
        continueB.SetActive(true);
        counter++;
        if (counter == 1)
        {
            done = counter;
        }
        else
        {
            done = counter;
        }
    }

    IEnumerator FadeAudio(AudioSource audio, float duration, float targetV)
    {
        float currentTime = 0;
        float start = audio.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audio.volume = Mathf.Lerp(start, targetV, currentTime/duration);
            yield return null;
        }
        yield break;
    }

   

    void CompleteGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("home");
    }
}
