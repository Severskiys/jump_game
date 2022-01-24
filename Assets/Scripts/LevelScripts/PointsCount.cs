using UnityEngine;
using UnityEngine.Events;

public class PointsCount : MonoBehaviour
{
    private Enemy[] _enemies;
    private StoryPoints[] _storyPoints;

    private int _overallGameScore = 0;
    private int _killEnemyPonts = 5;
    private int _collectStoryPoints = 10;

    public event UnityAction<int> PointsAmountChanged;

    private void Awake()
    {
        _enemies = FindObjectsOfType<Enemy>();
        _storyPoints = FindObjectsOfType<StoryPoints>();
    }

    private void OnEnable()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.DeathHappen += EnemyDeathPointsCount;
        }

        foreach (StoryPoints sp in _storyPoints)
        {
            sp.StoryPointCollected += StoryPointsCount;
        }
    }

    private void OnDisable()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.DeathHappen -= EnemyDeathPointsCount;
        }

        foreach (StoryPoints sp in _storyPoints)
        {
            sp.StoryPointCollected -= StoryPointsCount;
        }
    }

    private void StoryPointsCount()
    {
        _overallGameScore += _collectStoryPoints;
        PointsAmountChanged?.Invoke(_overallGameScore);
    }

    private void EnemyDeathPointsCount()
    {
        _overallGameScore += _killEnemyPonts;
        PointsAmountChanged?.Invoke(_overallGameScore);
    }

    public int GetPointsAmount()
    {
        return _overallGameScore;
    }
}

