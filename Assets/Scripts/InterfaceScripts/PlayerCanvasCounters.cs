using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCanvasCounters : MonoBehaviour
{
    [SerializeField] private Text _playerHpAmount;
    [SerializeField] private Player _player;

    [SerializeField] private Text _pointsAmount;
    [SerializeField] private PointsCount _pointsCount;


    private void OnEnable()
    {
        _player.DamageTaken += UpdateHpCounter;
        _pointsCount.PointsAmountChanged += UpdatePointsCounter;
    }

    private void OnDisable()
    {
        _player.DamageTaken -= UpdateHpCounter;
        _pointsCount.PointsAmountChanged -= UpdatePointsCounter;
    }

    private void UpdateHpCounter(int hp)
    {
        _playerHpAmount.text = hp.ToString();
    }

    private void UpdatePointsCounter(int points)
    {
        _pointsAmount.text = points.ToString();
    }
}
