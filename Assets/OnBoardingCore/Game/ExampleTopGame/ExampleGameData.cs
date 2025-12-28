using System;
using System.Collections.Generic;
using com.ksgames.core.abstractions.persistence;
using UnityEngine;

namespace OnBoardingCore.Game.ExampleTopGame
{
    [Serializable]
    public class ExampleGameData: IGameData
    {
        
        
        [SerializeField] private int _score;
        [SerializeField] private List<int> _entities;


        public int Score => _score;
        public List<int> Entities => _entities;
        
        public ExampleGameData( List<int> entities)
        {
            _score = 0;
            _entities = entities;
        }

        public void AutoUpdateDataOnLoad()
        {
            // if we need to refresh data from resources
        }

        public void SetScore(int o)
        {
            _score = o;
        }
    }
}