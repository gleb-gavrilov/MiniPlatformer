using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _pointsManager;
    [SerializeField] private Coin _coin;
    [SerializeField] private Text _text;

    private int _delay = 2;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
        StartCoroutine(SpawnCoins());
    }

    private void Update()
    {
        _text.text = $"Score: {Player.CoinsCount}";
    }

    private IEnumerator SpawnCoins()
    {
        for(int i = 0; i < _pointsManager.childCount; i++)
        {
            Instantiate(_coin, _pointsManager.GetChild(i).transform.position, Quaternion.identity);
            yield return _wait;
        }
    }
}
