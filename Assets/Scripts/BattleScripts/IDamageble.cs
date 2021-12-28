using UnityEngine.Events;
internal interface IDamageble
{
    public void TakeDamage(int dmg);
    public event UnityAction DeathHappen;
}