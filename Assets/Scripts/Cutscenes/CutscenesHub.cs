using UnityEngine;
using UnityEngine.SceneManagement;

public class CutscenesHub : MonoBehaviour
{
    private DialogPlayer _dialogPlayer;
    private Character _mainHero;
    private Character _director;
    private DialogueLine[] _currentDialogue;

    private DialogueLine[] _dialogueFirstLvlStart;
    private DialogueLine[] _dialogueSecondLvlStart;
    private DialogueLine[] _dialogueThirdLvlStart;
    private DialogueLine[] _dialogueFourLvlStart;
    private DialogueLine[] _dialogueFiveLvlStart;

    private DialogueLine[] _dialogueFirstLvlEnd;
    private DialogueLine[] _dialogueSecondLvlEnd;
    private DialogueLine[] _dialogueThirdLvlEnd;
    private DialogueLine[] _dialogueFourLvlEnd;
    private DialogueLine[] _dialogueFiveLvlEnd;

    private void Awake()
    {
        _dialogPlayer = GetComponent<DialogPlayer>();

        _mainHero = new Character("�����", true);
        _director = new Character("��������", false);

        _dialogueFirstLvlStart = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "� ������ ����, ����� ������� ��� �����..."),
            new DialogueLine (_mainHero, "...� ������� ���� ������"),
            new DialogueLine (_mainHero, "� ��� �� ������... "),
            new DialogueLine (_mainHero, "...����� � ��� ������!"),
            new DialogueLine (_mainHero, "..."),
            new DialogueLine (_mainHero, "��... ��� �� �������..."),
            new DialogueLine (_mainHero, "� �� ������..."),
            new DialogueLine (_mainHero, "�������� ��� ������������� �������..."),
            new DialogueLine (_director, "��������� �����"),
            new DialogueLine (_director, "��������������� ������ ����� ������"),
            new DialogueLine (_mainHero, "� ������� ����� ���..."),
            new DialogueLine (_mainHero, "� ���� ������ ������,"),
            new DialogueLine (_mainHero, "������� ����� ����� �����!"),
            new DialogueLine (_director, "�������� ��� ���������,"),
            new DialogueLine (_director, "������� ���������� -"),
            new DialogueLine (_director, "� ���� ��������� �����!")
        };

        _dialogueSecondLvlStart = new DialogueLine[]
        {
            new DialogueLine (_director, "����� �� ��������"),
            new DialogueLine (_director, "�� ������ ����� �� ������"),
            new DialogueLine (_director, "������� - ���� �������"),
            new DialogueLine (_director, "� ���� ���������"),
            new DialogueLine (_director, "�� ������� ��������������"),
            new DialogueLine (_director, "����� 15% ������� �������"),
            new DialogueLine (_director, "��������� ���� ����� ���� - "),
            new DialogueLine (_director, "������� ���!"),
        };

        _dialogueThirdLvlStart = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "� ����� ���..."),
            new DialogueLine (_mainHero, "���� ��� ���� �������?"),
            new DialogueLine (_director, "�����, ��������"),
            new DialogueLine (_director, "������ ���� �� ��������"),
            new DialogueLine (_director, "������ �� ����������"),
            new DialogueLine (_director, "� ������������ � �����"),
            new DialogueLine (_director, "��� �������"),
        };

        _dialogueFourLvlStart = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "��... ��... ����..."),
            new DialogueLine (_director, "�������� �������, ��������� �����"),
            new DialogueLine (_director, "����� � ���� ����..."),
            new DialogueLine (_director, "������ ��������!"),
        };

        _dialogueFiveLvlStart = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "�, ����� �������"),
            new DialogueLine (_mainHero, "������ ��������!"),
            new DialogueLine (_mainHero, "� ���� ����� �����"),
            new DialogueLine (_mainHero, "��������� ��� ���������!"),
        };

        // ������� ����� �������

        _dialogueFirstLvlEnd = new DialogueLine[]
       {
            new DialogueLine (_mainHero, "��... ��... ��..."),
            new DialogueLine (_director, "�����, ��� � ����?"),
            new DialogueLine (_mainHero, "��, ��, ��..."),
            new DialogueLine (_mainHero, "������� ��� ����� ������ � �������"),
            new DialogueLine (_director, "�� ��������?"),
            new DialogueLine (_mainHero, "���... �� � �� �����"),
            new DialogueLine (_director, "��... ��� �� �������!"),
       };

        _dialogueSecondLvlEnd = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "������� � ������� �������!"),
            new DialogueLine (_director, "�����, �� ��������?"),
            new DialogueLine (_mainHero, "� ���� � ������"),
            new DialogueLine (_mainHero, "������� �����..."),
            new DialogueLine (_director, "��... ��� �� �������!"),
        };

        _dialogueThirdLvlEnd = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "�� ��������..."),
            new DialogueLine (_mainHero, "��� ������ � ��������?"),
            new DialogueLine (_director, "��, � � ���� �� ���"),
            new DialogueLine (_director, "������� �������"),
            new DialogueLine (_mainHero, "� ���� ���� �� ����������..."),
            new DialogueLine (_director, "���, �������..."),
            new DialogueLine (_director, "� ������� ���,"),
            new DialogueLine (_director, "����� �� ���� ��� �������"),
            new DialogueLine (_director, "��� �������� � �����������"),
            new DialogueLine (_director, "������ �������"),
            new DialogueLine (_director, "� �� ���� �� ������..."),
        };

        _dialogueFourLvlEnd = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "��... ��... ����..."),
            new DialogueLine (_director, "�����, ������!"),
            new DialogueLine (_director, "� ����� ������ �����"),
            new DialogueLine (_mainHero, "��� ���� ��������� �����!"),
        };

        _dialogueFiveLvlEnd = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "����� �����..."),
            new DialogueLine (_mainHero, "��������� ����� � ����!"),
            new DialogueLine (_mainHero, "���� ��� � ����������..."),
            new DialogueLine (_director, "�����!"),
        };
    }

    public void PlayDialogFirstLvlStart()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                _currentDialogue = _dialogueFirstLvlStart;
                break;
            case 1:
                _currentDialogue = _dialogueSecondLvlStart;
                break;
            case 2:
                _currentDialogue = _dialogueThirdLvlStart;
                break;
            case 3:
                _currentDialogue = _dialogueFourLvlStart;
                break;
            case 4:
                _currentDialogue = _dialogueFiveLvlStart;
                break;
        }
        _dialogPlayer.StartCutScene(_currentDialogue);
    }

    public void PlayDialogFirstLvlEnd()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                _currentDialogue = _dialogueFirstLvlEnd;
                break;
            case 1:
                _currentDialogue = _dialogueSecondLvlEnd;
                break;
            case 2:
                _currentDialogue = _dialogueThirdLvlEnd;
                break;
            case 3:
                _currentDialogue = _dialogueFourLvlEnd;
                break;
            case 4:
                _currentDialogue = _dialogueFiveLvlEnd;
                break;
        }
        _dialogPlayer.StartCutScene(_currentDialogue); 
    }


}
