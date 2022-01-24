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

        _mainHero = new Character("Актер", true);
        _director = new Character("Режиссер", false);

        _dialogueFirstLvlStart = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "Я пришел сюда, чтобы сказать эту фразу..."),
            new DialogueLine (_mainHero, "...и надрать жопы крабам"),
            new DialogueLine (_mainHero, "и как вы поняли... "),
            new DialogueLine (_mainHero, "...фразу я уже сказал!"),
            new DialogueLine (_mainHero, "..."),
            new DialogueLine (_mainHero, "Фу... что за барахло..."),
            new DialogueLine (_mainHero, "я же просил..."),
            new DialogueLine (_mainHero, "написать мне драматический монолог..."),
            new DialogueLine (_director, "Гражданин актер"),
            new DialogueLine (_director, "драматизировать будете после съемок"),
            new DialogueLine (_mainHero, "А давайте лучше так..."),
            new DialogueLine (_mainHero, "я буду мстить крабам,"),
            new DialogueLine (_mainHero, "которые съели моего друга!"),
            new DialogueLine (_director, "Сценарий уже утвержден,"),
            new DialogueLine (_director, "начнете выдумывать -"),
            new DialogueLine (_director, "я буду прерывать дубль!")
        };

        _dialogueSecondLvlStart = new DialogueLine[]
        {
            new DialogueLine (_director, "жучка мы прогнали"),
            new DialogueLine (_director, "Но сильно легче не станет"),
            new DialogueLine (_director, "Впереди - лужы кислоты"),
            new DialogueLine (_director, "А наша страховка"),
            new DialogueLine (_director, "Не покроет восстановление"),
            new DialogueLine (_director, "более 15% кожного покрова"),
            new DialogueLine (_director, "Навредишь себе сверх меры - "),
            new DialogueLine (_director, "Заменим вас!"),
        };

        _dialogueThirdLvlStart = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "А можно мне..."),
            new DialogueLine (_mainHero, "хоть еще одну реплику?"),
            new DialogueLine (_director, "Актер, смотрите"),
            new DialogueLine (_director, "ничего себе не защемите"),
            new DialogueLine (_director, "прыгая по платформам"),
            new DialogueLine (_director, "а наговориться в кадре"),
            new DialogueLine (_director, "еще успеете"),
        };

        _dialogueFourLvlStart = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "ах... ах... абвз..."),
            new DialogueLine (_director, "Сомкните челюсть, гражданин актер"),
            new DialogueLine (_director, "Ветер в рожу дует..."),
            new DialogueLine (_director, "съемка стартует!"),
        };

        _dialogueFiveLvlStart = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "О, крабы позвали"),
            new DialogueLine (_mainHero, "своего старшого!"),
            new DialogueLine (_mainHero, "С него можно будет"),
            new DialogueLine (_mainHero, "накормить все поселение!"),
        };

        // ДИАЛОГИ КОНЦА ЛЕВЕЛОВ

        _dialogueFirstLvlEnd = new DialogueLine[]
       {
            new DialogueLine (_mainHero, "Ай... Ой... Ай..."),
            new DialogueLine (_director, "Актер, что с вами?"),
            new DialogueLine (_mainHero, "Ой, ой, ой..."),
            new DialogueLine (_mainHero, "Кажется мне жучек заполз в ботинок"),
            new DialogueLine (_director, "Вы умираете?"),
            new DialogueLine (_mainHero, "Нет... Но я их боюсь"),
            new DialogueLine (_director, "Эх... Все на перерыв!"),
       };

        _dialogueSecondLvlEnd = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "Кажется я вдохнул кислоту!"),
            new DialogueLine (_director, "Актер, вы умираете?"),
            new DialogueLine (_mainHero, "У меня в легких"),
            new DialogueLine (_mainHero, "странно шипит..."),
            new DialogueLine (_director, "Эх... Все на перерыв!"),
        };

        _dialogueThirdLvlEnd = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "Вы получили..."),
            new DialogueLine (_mainHero, "мои правки к сценарию?"),
            new DialogueLine (_director, "Да, и я жарю на них"),
            new DialogueLine (_director, "вкусные сосиски"),
            new DialogueLine (_mainHero, "И ведь даже не поделитесь..."),
            new DialogueLine (_director, "Нет, конечно..."),
            new DialogueLine (_director, "В прошлый раз,"),
            new DialogueLine (_director, "когда мы дали вам сосиску"),
            new DialogueLine (_director, "она застряла в респираторе"),
            new DialogueLine (_director, "вашего костюма"),
            new DialogueLine (_director, "и вы чуть не умерли..."),
        };

        _dialogueFourLvlEnd = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "ах... ах... абвз..."),
            new DialogueLine (_director, "Актер, дышите!"),
            new DialogueLine (_director, "и идите против ветра"),
            new DialogueLine (_mainHero, "вас ждет последний рывок!"),
        };

        _dialogueFiveLvlEnd = new DialogueLine[]
        {
            new DialogueLine (_mainHero, "Люблю запах..."),
            new DialogueLine (_mainHero, "жаренного краба с утра!"),
            new DialogueLine (_mainHero, "хотя уже и смеркается..."),
            new DialogueLine (_director, "СНЯТО!"),
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
