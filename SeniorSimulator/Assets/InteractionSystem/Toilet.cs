using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toilet : MonoBehaviour, IInteractable
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
    public Text option11Text;
    public Text option13Text;
    public Text option31Text;
    public Text option33Text;
    public Player player;
    public AudioSource audioSource;
    public AudioClip pooSound;
    public AudioClip peeSound;
    public AudioClip sitSound;

    public bool Interact(Interactor interactor)
    {
        GameObject timeController = GameObject.Find("TimeController");
        TimeController timeControllerScript = timeController.GetComponent<TimeController>();

        interactionPrompt.gameObject.SetActive(false);
        image.gameObject.SetActive(false);
        option12.gameObject.SetActive(false);
        option22.gameObject.SetActive(false);
        option21.gameObject.SetActive(false);
        option23.gameObject.SetActive(false);
        option32.gameObject.SetActive(false);
        option11.gameObject.SetActive(true);
        option13.gameObject.SetActive(true);
        option31.gameObject.SetActive(true);
        option33.gameObject.SetActive(true);
        Debug.Log("Toilet");
        panel.SetActive(true);
        Time.timeScale = 0;
        option11Text.text = "Poo";
        option13Text.text = "Poo with mobile phone";
        option31Text.text = "Pee";
        option33Text.text = "Just sit";
        option11.onClick.AddListener(() => {
            audioSource.PlayOneShot(pooSound, 0.2f);
            Debug.Log("Poo");
            panel.SetActive(false);
            player.Heal(1);
            player.DecreaseHunger(10);
            player.IncreaseWellBeing(7);
            timeControllerScript.AddHoursToTime(0.25);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option13.onClick.AddListener(() => {
            audioSource.PlayOneShot(pooSound, 0.2f);
            Debug.Log("Poo with mobile phone");
            panel.SetActive(false);
            player.Heal(3);
            player.DecreaseHunger(15);
            player.IncreaseWellBeing(10);
            timeControllerScript.AddHoursToTime(0.5);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option31.onClick.AddListener(() => {
            audioSource.PlayOneShot(peeSound, 0.2f);
            Debug.Log("Pee");
            panel.SetActive(false);
            player.Heal(1);
            player.DecreaseHunger(1);
            player.IncreaseWellBeing(1);
            timeControllerScript.AddHoursToTime(0.1);
            interactionPrompt.gameObject.SetActive(true);
            Time.timeScale = 1;
            RemoveListeners();
        });
        option33.onClick.AddListener(() => {
            audioSource.PlayOneShot(sitSound, 0.2f);
            Debug.Log("Just sit");
            panel.SetActive(false);
            timeControllerScript.AddHoursToTime(0.3);
            player.Heal(5);
            player.DecreaseHunger(2);
            player.DecreaseWellBeing(2);
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
