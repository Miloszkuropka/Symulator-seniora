using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TVUnit : MonoBehaviour, IInteractable
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
        Debug.Log("TV interaction");
        panel.SetActive(true);
        Time.timeScale = 0;
        option11Text.text = "News";
        option13Text.text = "Some Turkish series";
        option31Text.text = "The colors of happiness";
        option33Text.text = "Eurosport";

        System.Random r = new System.Random();
        int rInt = r.Next(-5, 5);

        option11.onClick.AddListener(() => { 
            Debug.Log("Watching News"); 
            panel.SetActive(false);
            player.Heal(5);
            player.DecreaseHunger(5);
            player.DecreaseWellBeing(rInt);
            timeControllerScript.AddHoursToTime(0.3);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option13.onClick.AddListener(() => { 
            Debug.Log("Watching Some Turkish series"); 
            panel.SetActive(false);
            player.Heal(5);
            player.DecreaseHunger(10);
            player.IncreaseWellBeing(10);
            timeControllerScript.AddHoursToTime(0.7);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option31.onClick.AddListener(() => { 
            Debug.Log("Watching The colors of happiness"); 
            panel.SetActive(false);
            player.Heal(5);
            player.DecreaseHunger(7);
            player.IncreaseWellBeing(5);
            timeControllerScript.AddHoursToTime(0.6);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
        option33.onClick.AddListener(() => { 
            Debug.Log("Watching Eurosport");
            panel.SetActive(false);
            timeControllerScript.AddHoursToTime(1.2);
            player.Heal(5);
            player.DecreaseHunger(10);
            player.IncreaseWellBeing(5);
            interactionPrompt.gameObject.SetActive(true); 
            Time.timeScale = 1;
            RemoveListeners(); });
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
