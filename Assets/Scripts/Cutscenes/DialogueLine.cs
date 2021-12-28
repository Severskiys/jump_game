public class DialogueLine
{
    private Character _character;
    private string _phrase;

    public DialogueLine(Character character, string phrase)
    {
        _character = character;
        _phrase = phrase;
    }

    public string CharacterName()
    {
        return _character.Name();
    }

    public bool IsMainHero()
    {
        return _character.IsMainHero();
    }

    public string Pharse()
    {
        return _phrase;
    }

}
