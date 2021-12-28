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
        _mainHero = new Character("Стебель", true);
        _director = new Character("Режиссер", false);

        _dialogueLines = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "Я пришел сюда чтобы сказать эту фразу и надрать жопы крабам"),
            new DialogueLine (_mainHero, "и как вы поняли фразу я уже сказал!"),
            new DialogueLine (_mainHero, "..."),
            new DialogueLine (_mainHero, "Фу... что за барахло..."),
            new DialogueLine (_mainHero, "я же просил... написать драматический монолог для этой сцены..."),
            new DialogueLine (_director, "Это комединый боевик"),
            new DialogueLine (_director, "драматизировать можете после съемок"),
            new DialogueLine (_director, "у нас тут итак дорогое оборудование в болотах гниет"),
            new DialogueLine (_mainHero, "А может..."),
            new DialogueLine (_mainHero, "это будут крабы... которые съели моего друга..."),
            new DialogueLine (_mainHero, "и я пришел им отомстить!?"),
            new DialogueLine (_director, "Гражданин актер, давайте строго по тексту,"),
            new DialogueLine (_director, "если начнете выдумывать, я буду прерывать дубль.")
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
