using Cinemachine;
using UnityEngine;
using TMPro;
using System.Collections;


public class DialogPlayer : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cutScenesCam;
    [SerializeField] private Canvas _cutscenesCanvas;
    [SerializeField] private Canvas _dialogCanvas;
    [SerializeField] private TMP_Text _mainCharName;
    [SerializeField] private TMP_Text _secondCharName;
    [SerializeField] private TMP_Text _DialogueText;

    private PlayerInputWrapper _playerInputActions;
    private Animator _canvasAnimator;

    private int _dialogueIndex;

    private DialogueLine[] _dialogue;

    private void Awake()
    {
        _playerInputActions = FindObjectOfType<PlayerInputWrapper>();
        _canvasAnimator = _cutscenesCanvas.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerInputActions.IsNextMessegeSelected += OnNextDialog;
    }

    private void OnDisable()
    {
        _playerInputActions.IsNextMessegeSelected -= OnNextDialog;
    }

    public void StartCutScene(DialogueLine[] dialogue)
    {
      _dialogueIndex = 0;
      _dialogue = dialogue;
      _playerInputActions.SwitchInputSchemaToCutscenes();
      _cutScenesCam.Priority = 50;
      _cutscenesCanvas.gameObject.SetActive(true);
      _dialogCanvas.gameObject.SetActive(true);
      OnNextDialog();
    }

    private void OnNextDialog()
    {
        if (_dialogueIndex < _dialogue.Length)
        {
            PlayDialog(_dialogue[_dialogueIndex]);
            _dialogueIndex++;
        }
        else
        {
            StopCutScene();
        }
    }

    private void PlayDialog(DialogueLine dialogueLine)
    {
        if (dialogueLine.IsMainHero())
        {
            _mainCharName.text = dialogueLine.CharacterName();
            _secondCharName.text = " ";
            _DialogueText.color = Color.cyan;
        }
        else
        {
            _mainCharName.text = " ";
            _secondCharName.text = dialogueLine.CharacterName();
            _DialogueText.color = Color.blue;
        }
        _DialogueText.text = dialogueLine.Pharse();
    }

    private void StopCutScene()
    {
        _playerInputActions.SwitchInputSchemaToPlayer();
        _cutScenesCam.Priority = 5;
        _dialogCanvas.gameObject.SetActive(false);
        _canvasAnimator.Play("CutSceneCanvasDisappear");
        StartCoroutine(WaitAndSetCanvasFalse());
    }

    private IEnumerator WaitAndSetCanvasFalse()
    {
        yield return new WaitForSeconds(1f);
        _cutscenesCanvas.gameObject.SetActive(false);
    }


}
