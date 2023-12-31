using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chair : MonoBehaviour, IInteractable
{

    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public GameObject panel;
    public Button option11;
    public Button option12;
    public Button option13;
    public Button option21;
    public Button option22;
    public Button option23;
    public Button option31;
    public Button option32;
    public Button option33;
    public Button exit;
    public Image image;
    public Canvas interactionPrompt;
    public Text option12Text;
    public Text option22Text;
    public Text option32Text;
    public Player player;

    public AudioSource audioSource;
    public AudioClip sitSound;
    public AudioClip chairSound;
    public AudioClip complainSound;

    public bool Interact(Interactor interactor)
    {
        GameObject timeController = GameObject.Find("TimeController");
        TimeController timeControllerScript = timeController.GetComponent<TimeController>();

        interactionPrompt.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        option11.gameObject.SetActive(false);
        option12.gameObject.SetActive(true);
        option13.gameObject.SetActive(false);
        option21.gameObject.SetActive(false);
        option22.gameObject.SetActive(true);
        option23.gameObject.SetActive(false);
        option31.gameObject.SetActive(false);
        option32.gameObject.SetActive(true);
        option33.gameObject.SetActive(false);
        Debug.Log("Chair");
        panel.SetActive(true);
        Time.timeScale = 0;
        option12Text.text = "Just sit";
        option22Text.text = "Dance on a chair";
        option32Text.text = "Sit and complain";
        option12.onClick.AddListener(() => {
            audioSource.PlayOneShot(sitSound, 0.2f);
            Debug.Log("Selected Just sit");
            panel.SetActive(false);
            player.Heal(2);
            player.DecreaseHunger(1);
            player.DecreaseWellBeing(1);
            timeControllerScript.AddHoursToTime(0.15);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option22.onClick.AddListener(() => {
            audioSource.PlayOneShot(chairSound, 0.1f);
            Debug.Log("Selected Dance on a chair");
            panel.SetActive(false);
            player.TakeDamage(3);
            player.DecreaseHunger(3);
            player.IncreaseWellBeing(5);
            timeControllerScript.AddHoursToTime(0.1);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option32.onClick.AddListener(() => {
            audioSource.PlayOneShot(complainSound, 0.2f);
            Debug.Log("Selected Sit and complain");
            panel.SetActive(false);
            player.Heal(3);
            player.DecreaseHunger(1);
            player.DecreaseWellBeing(4);
            timeControllerScript.AddHoursToTime(0.2);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        exit.onClick.AddListener(() => {
            panel.SetActive(false);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        return true;
    }
    void RemoveListeners()
    {
        option11.onClick.RemoveAllListeners();
        option12.onClick.RemoveAllListeners();
        option13.onClick.RemoveAllListeners();
        option21.onClick.RemoveAllListeners();
        option22.onClick.RemoveAllListeners();
        option23.onClick.RemoveAllListeners();
        option31.onClick.RemoveAllListeners();
        option32.onClick.RemoveAllListeners();
        option33.onClick.RemoveAllListeners();
        exit.onClick.RemoveAllListeners();
    }
}

