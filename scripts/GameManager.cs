using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CallingCardScript callingCard;
    public InviCardScript inviCardScript;
    public Newspaper newspaper;
    public LightSwitch lightSwitch;
    public SwitchLight switchLight;
    public DoorControl door;
    public GameObject newspaperImage;
    public GameObject lightUI;
    public GameObject inviCard;
    public GameObject card;
    public GameObject passcode;
    public GameObject cameraM;
    public GameObject player;
    public GameObject background;
    public GameObject clue2;
    public GameObject menu;
    public CanvasGroup bg;
    public CanvasGroup bgBlack;
    public Transform resume;
    public Transform quit;
    public Light lightToggle;
    public bool screenOverlayed = false;
    public bool menuScreen = false;
    public AudioSource lightS;
    public AudioSource click;
    public AudioSource openS;


    void Start()
    {
        if(PlayerPrefs.HasKey("GameRun") == false)
        {
            PlayerPrefs.SetInt("GameRun", 1);
            PlayerPrefs.SetInt("LightPass", 0);
            //show tutorial
            PlayerPrefs.Save();
        }
    }


    
    void Update()
    {
        if (menuScreen == false)
        {
            if (screenOverlayed == true)
            {
                Cursor.visible = true;
                cameraM.GetComponent<CameraMovement>().enabled = false;
                player.GetComponent<PlayerMovement>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.lockState = CursorLockMode.Confined;
                background.SetActive(true);
            }
            else
            {
                Cursor.visible = false;
                cameraM.GetComponent<CameraMovement>().enabled = true;
                player.GetComponent<PlayerMovement>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;         
                background.SetActive(false);
            }
        }
        


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            openS.Play();
            cameraM.GetComponent<CameraMovement>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;
            bg.LeanAlpha(1f, .6f);
            resume.LeanMoveX(Screen.width/4, 1f).setEaseOutExpo();
            quit.LeanMoveX(Screen.width/4, 1f).setEaseOutExpo();
            menuScreen = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined; 
            menu.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (door.doorInSightU == true)
            {
                openS.Play();
                passcode.SetActive(!passcode.activeSelf);

                if (passcode.activeSelf == true)
                {
                    screenOverlayed = true;
                }
                else
                {
                    screenOverlayed = false;
                }
            }

            if (door.doorInSightO == true)
            {
                bgBlack.gameObject.SetActive(true);
                openS.Play();
                bgBlack.LeanAlpha(1f, 2f).setOnComplete(GameEnd).delay = .2f;
            }



            if (callingCard.cardInsight == true)
            {
                openS.Play();
                card.SetActive(!card.activeSelf);

                if (card.activeSelf == true)
                {
                    screenOverlayed = true;
                }
                else
                {
                    screenOverlayed = false;
                }
            }

            if (inviCardScript.inviCardInsight == true)
            {
                openS.Play();
                inviCard.SetActive(!inviCard.activeSelf);

                if (inviCard.activeSelf == true)
                {
                    screenOverlayed = true;
                }
                else
                {
                    screenOverlayed = false;
                }
            }

            if (newspaper.newspaperInSight == true)
            {
                openS.Play();
                newspaperImage.SetActive(!newspaperImage.activeSelf);

                if (newspaperImage.activeSelf == true)
                {
                    screenOverlayed = true;
                }
                else
                {
                    screenOverlayed = false;
                }
            }

            if (lightSwitch.switchCodeSight == true)
            {
                openS.Play();
                lightUI.SetActive(!lightUI.activeSelf);

                if (lightUI.activeSelf == true)
                {
                    screenOverlayed = true;
                }
                else
                {
                    screenOverlayed = false;
                }
            }

            if (lightSwitch.switchInSight == true)
            {
                lightS.Play();
                clue2.SetActive(!clue2.activeSelf);
                lightToggle.enabled = !lightToggle.enabled;
            }
        }   
    }

    public void DonePasscode()
    {
        door.doorInSightO = true;
        door.doorInSightU = false;
        passcode.SetActive(false);
        screenOverlayed = false;
    }

    public void DoneLightPasscode()
    {
        PlayerPrefs.SetInt("LightPass", 1);
        lightSwitch.switchInSight = true;
        lightSwitch.switchCodeSight = false;
        lightUI.SetActive(false);
        screenOverlayed = false;
        PlayerPrefs.Save();
    }

    public void Resume()
    {
        resume.LeanMoveX(Screen.width - Screen.width - 500, .7f).setEaseInQuint();
        quit.LeanMoveX(Screen.width - Screen.width - 400, .7f).setEaseInQuint();
        bg.LeanAlpha(0f, .8f).setOnComplete(ResumeM).delay = .1f;
    }

    public void Quit()
    {
        bgBlack.gameObject.SetActive(true);
        resume.LeanMoveX(-500f, .7f).setEaseInQuint();
        quit.LeanMoveX(-400f, .7f).setEaseInQuint();
        bgBlack.LeanAlpha(1f, 1.2f).setOnComplete(QuitM).delay = .1f;
    }


    void ResumeM()
    {
        menuScreen = false;
        Cursor.visible = false;  
        cameraM.GetComponent<CameraMovement>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        menu.SetActive(false);
    }

    void QuitM()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ClickBot()
    {
        click.Play();
    }

    void GameEnd()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
