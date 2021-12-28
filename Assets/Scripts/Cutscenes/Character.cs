public class Character
{
    private string _name;
    private bool _isMainHero;

    public Character(string name, bool isMainHero)
    {
        _name = name;
        _isMainHero = isMainHero;
    }

    public string Name()
    {
        return _name;
    }

    public bool IsMainHero()
    {
        return _isMainHero;
    }
}