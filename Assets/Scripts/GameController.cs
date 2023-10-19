using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public TMP_Text dialogueText;
    public TMP_Text playerStatsText;
    public TMP_InputField playerNameInput;
    public TMP_InputField strengthInput;
    public TMP_InputField dexterityInput;
    public TMP_InputField healthInput;
    public TMP_Text option1Text;
    public TMP_Text option2Text;
    public Button createPlayerButton;
    public Button option1Button;
    public Button option2Button;


    private Player player;
    private GameManager gameManager;

    void Start()
    {
        gameManager = new GameManager();
        player =  gameObject.AddComponent<Player>();

        createPlayerButton.onClick.AddListener(CreatePlayer);
        option1Button.onClick.AddListener(() => ChooseOption(0));
        option2Button.onClick.AddListener(() => ChooseOption(1));

        UpdateUI();
    }

    void CreatePlayer()
    {
        string playerName = playerNameInput.text;
        int strength, dexterity, health;

        if (int.TryParse(strengthInput.text, out strength) && int.TryParse(dexterityInput.text, out dexterity) && int.TryParse(healthInput.text, out health))
        {
            int remainingPoints = 100 - (strength + dexterity + health);

            if (remainingPoints >= 0)
            {
                player.CreatePlayer(playerName, strength, dexterity, remainingPoints, health);
                gameManager.StartGame();
                playerStatsText.text = player.GetStats();
            }
        }
    }

    void ChooseOption(int optionIndex)
    {
        gameManager.SelectOption(optionIndex);
        UpdateUI();
    }

    void UpdateUI()
    {
        dialogueText.text = gameManager.CurrentDialogue;
        playerStatsText.text = player.GetStats();
        option1Button.interactable = gameManager.HasOption(0);
        option2Button.interactable = gameManager.HasOption(1);
        option1Text.text = gameManager.GetOptionText(0);
        option2Text.text = gameManager.GetOptionText(1);
    }
}

public class GameManager
{
    private Player player;
    private int currentDialogueIndex;
    private List<Dialogue> dialogues;


    public string CurrentDialogue => dialogues[currentDialogueIndex].Text;

    public GameManager()
    {
        player = new Player();
        dialogues = new List<Dialogue>
        {
            new Dialogue("¡Bienvenido a la aventura! Crea tu personaje y elige un camino.",
                new List<Option>
                {
                    //fuerza, destreza, vida
                    new Option("A) Camino de la fuerza", 10, 0, 0, () => { }), 
                    new Option("B) Camino de la destreza", 0, 10, 0, () => { }),

                }),
            new Dialogue("Has llegado a un cruce en el camino. ¿Qué haces?",
                new List<Option>
                {
                    new Option("A) Ir a la izquierda", 0, 0, 0, () => { }),
                    new Option("B) Ir a la derecha", 0, 5, -5, () => { }),
                }),
            new Dialogue("Estas en un cuarto completamente oscuro",
            new List<Option>
                {
                    new Option("A) Buscas algo para iluminar el cuarto", 0, 0, 0, () => { }),

                    new Option("B) Sigues adelante sin importar nada", 0, 5, -5, () => { }),
                }),
        };
    }

    public Player Player => player;

    public void StartGame()
    {
        currentDialogueIndex = 0;
    }

    public bool HasOption(int optionIndex)
    {
        return optionIndex >= 0 && optionIndex < dialogues[currentDialogueIndex].Options.Count;
    }

    public void SelectOption(int optionIndex)
    {
        if (HasOption(optionIndex))
        {
            Option option = dialogues[currentDialogueIndex].Options[optionIndex];
            option.OnSelect();
            currentDialogueIndex++;
        }
    }

    public string GetOptionText(int optionIndex)
    {
        if (HasOption(optionIndex))
        {
            return dialogues[currentDialogueIndex].Options[optionIndex].Text;
        }
        return string.Empty;
    }

}
