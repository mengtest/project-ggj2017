﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get { return _instance; }
    }
    private static GameManager _instance;

    private void Awake()
    {
        _instance = this;
    }

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }
    private int _score;

    public int CurStage
    {
        get { return _curStage; }
        set
        {
            _curStage = value;
            RadiusDataManager.Instance.SetLevel(_curStage);
        }
    }
    private int _curStage;

    [SerializeField] private int[] _stageScore;
    [SerializeField] private AnimationCurve[] _stagePatterns;

    public void AddScore()
    {
        Score++;

        if (Score >= _stageScore[CurStage])
        {
            if(CurStage != _stageScore.Length - 1)
            {
                CurStage++;
            }
        }

        UIManager.Instance.OnScoreChanged(_score);
    }

    public AnimationCurve GetCurrentPattern()
    {
        return _stagePatterns[_curStage];
    }

    public void ResetGame()
    {
        CurStage = 0;
        Score = 0;

        RadiusDataManager.Instance.SetLevel (_curStage);
        UIManager.Instance.OnScoreChanged(_score);
    }
}
