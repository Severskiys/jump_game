using UnityEngine;

public class StoryDialog : MonoBehaviour
{
    private CutscenesSwitch _cutscenesSwitch;
    private Character _mainHero;
    private Character _director;
    private DialogueLine[] _dialogueLines;

    private void Awake()
    {
        _cutscenesSwitch = GetComponentInParent<CutscenesSwitch>();
        _mainHero = new Character("�������", true);
        _director = new Character("��������", false);

        _dialogueLines = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "� ������ ���� ����� ������� ��� ����� � ������� ���� ������"),
            new DialogueLine (_mainHero, "� ��� �� ������ ����� � ��� ������!"),
            new DialogueLine (_mainHero, "..."),
            new DialogueLine (_mainHero, "��... ��� �� �������..."),
            new DialogueLine (_mainHero, "� �� ������... �������� ������������� ������� ��� ���� �����..."),
            new DialogueLine (_director, "��� ��������� ������"),
            new DialogueLine (_director, "��������������� ������ ����� ������"),
            new DialogueLine (_director, "� ��� ��� ���� ������� ������������ � ������� �����"),
            new DialogueLine (_mainHero, "� �����..."),
            new DialogueLine (_mainHero, "��� ����� �����... ������� ����� ����� �����..."),
            new DialogueLine (_mainHero, "� � ������ �� ���������!?"),
            new DialogueLine (_director, "��������� �����, ������� ������ �� ������,"),
            new DialogueLine (_director, "���� ������� ����������, � ���� ��������� �����.")
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _cutscenesSwitch.StartCutScene(_dialogueLines);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Destroy(gameObject);
        }
    }
}
