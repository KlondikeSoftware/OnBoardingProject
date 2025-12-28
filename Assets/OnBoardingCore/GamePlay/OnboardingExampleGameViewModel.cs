using com.ksgames.core.gamecore.topgame.viewmodels;
using Lukomor.Reactive;
using OnBoardingCore.Game.ExampleTopGame;
using OnBoardingCore.Game.ExampleTopGame._Entities;
using System.Linq;
using System.Collections.Generic;
using System;
using com.ksgames.core.uitools;
using UnityEngine;
using Random = UnityEngine.Random;

namespace OnBoardingCore.Game
{
    public class OnboardingExampleGameViewModel : RootTopGameViewModel
    {
        private ExampleGameService _gameService;
        public ReactiveProperty<string> Caption => _caption;
        private ReactiveProperty<string> _caption;


        public ReactiveProperty<int> Score => _gameService.Score;
        public ReactiveCollection<EntityViewModel> EntitiesVM => _entitiesVM;
        private ReactiveCollection<EntityViewModel> _entitiesVM = new();

        public UIButtonViewModel AddEntityButtonViewModel { get; }
        public UIButtonViewModel RemoveEntityButtonViewModel { get; }
        public UIButtonViewModel AddScoreButtonViewModel { get; }

        private List<EntityViewModel> _entitiesMap = new();


        public OnboardingExampleGameViewModel(ExampleGameService gameService)
        {
            _gameService = gameService;
            _caption = new("Example Game View Model");
            _gameService.Entities.Added.Subscribe(OnAddEntity);
            _gameService.Entities.Removed.Subscribe(OnRemoveEntity);


            AddEntityButtonViewModel = new UIButtonViewModel("Add Entity", AddEntity);
            RemoveEntityButtonViewModel = new UIButtonViewModel("Remove Entity", RemoveEntity);
            AddScoreButtonViewModel = new UIButtonViewModel("Add Score", AddScore);
        }

        private void OnRemoveEntity(int o)
        {
            // best way to use entity Id for any entity in the game
            var vm = _entitiesVM.FirstOrDefault(x => x.Value.Value == o);
            _entitiesVM.Remove(vm);
            _entitiesMap.Remove(vm);
        }

        private void OnAddEntity(int o)
        {
            var vm = new EntityViewModel(o);
            _entitiesVM.Add(vm);
            _entitiesMap.Add(vm);
        }


        public void AddScore()
        {
            var rnd = Random.Range(1, 10);
            _gameService.ChangeScore(rnd);
        }

        public void AddEntity()
        {
            var rnd = Random.Range(1, 10);
            _gameService.AddEntity(rnd);
        }

        public void RemoveEntity()
        {
            var item = _entitiesMap.FirstOrDefault();
            _gameService.RemoveEntity(item?.Value.Value ?? 0);
        }
    }
}