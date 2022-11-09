using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Text _text;

    private Player _player;

    public void SetScore(int value)
    {
        _text.text = $"Score: {value}";
    }

    private void OnEnable()
    {
        if (_player == null)
        {
            _player = FindObjectOfType<Player>();
            _player.AddListener(SetScore);
        }
    }

    private void OnDisable()
    {
        _player.RemoveListener(SetScore);
    }
}
