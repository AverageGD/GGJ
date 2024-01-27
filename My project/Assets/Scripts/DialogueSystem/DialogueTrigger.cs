using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueTrigger : Interactable
{
    [SerializeField] private Dialogue[] _dialogues;
    [SerializeField] private Dialogue[] _jokes;
    [SerializeField] private GameObject[] _jokeButtons;
    [SerializeField] private GameObject _jokeBox;
    [SerializeField] private GameObject _spriteBillboard;
    [SerializeField] private Material _normalMaterial;
    [SerializeField] private Sprite _normalSprite;  
    [SerializeField] private float _delayTime;

    public int dialogueIndex = 0;
    public UnityEvent OnDialogueEnd;
    public bool isDead = false;
    public int id;
    public int rightAnswer;
    public int itemId;

    private float lastClickTime = 0;
    private int indexOfCurrentSentence = 0;


    public override void Interact()
    {
        base.Interact();

        if (Time.time - lastClickTime > _delayTime && !_jokeBox.activeSelf)
        {
            for (int i = 0; i < _jokeButtons.Length; i++)
            {
                _jokeButtons[i].GetComponent<Text>().text = _jokes[i].sentences[0];
                _jokeButtons[i].GetComponent<JokeLogics>().id = i;
                _jokeButtons[i].GetComponent<JokeLogics>().enemyId = id;
                _jokeButtons[i].GetComponent<JokeLogics>().itemId = itemId;
            }

            if (indexOfCurrentSentence == 0)
            {
                DialogueManager.instance.StartDialogue(_dialogues[dialogueIndex]);

            }
            else if (indexOfCurrentSentence == _dialogues[dialogueIndex].sentences.Length)
            {
                DialogueManager.instance.EndDialogue();
                OnDialogueEnd?.Invoke();
                dialogueIndex++;
                dialogueIndex = Mathf.Clamp(dialogueIndex, 0, _dialogues.Length - 1);

            }
            else
            {
                DialogueManager.instance.DisplayNextSentence();
            }

            lastClickTime = Time.time;

            indexOfCurrentSentence++;
            indexOfCurrentSentence %= (_dialogues[dialogueIndex].sentences.Length + 1);
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        indexOfCurrentSentence = 0;
        Debug.Log("ASS");
        DialogueManager.instance.EndDialogue();
    }


    private void Update()
    {
        if (isDead)
        {
            _spriteBillboard.GetComponent<SpriteRenderer>().material = _normalMaterial;
            _spriteBillboard.GetComponent<SpriteRenderer>().sprite = _normalSprite;
        }
    }
}