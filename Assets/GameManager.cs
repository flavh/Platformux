using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int _score;

    private void Start()
    {
        
    }

    public void AddScore(int score)
    {
        _score += score;
    }
}