using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinStats : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Player _player;

    private void Update()
    {
        _text.text = $"Score: {_player.CoinsCount}";
    }
}
