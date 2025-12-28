using System;
using System.Collections;
using com.ksgames.core.architect;
using com.ksgames.core.gamecore;
using com.ksgames.core.gamecore.sceneservice;
using com.ksgames.core.gamecore.sceneservice.sceneentrypoint;
using com.ksgames.core.gamecore.sceneservice.viewmodels;
using Lukomor.DI;
using OnBoardingCore.Game.ExampleTopGame;
using R3;
using UnityEngine;

namespace OnBoardingCore.GameLoader
{
    public class OnboardingGameLoaderEntryPoint: SceneEntryPoint, IDisposable
    {
        new UIGameLoaderViewModel _uiViewModel;
        
        private CompositeDisposable _subscriptionBag = new();
        
        public override void Process(DIContainer gameContainer)
        {
            // base.Process(gameContainer);
            
            // _container = gameContainer;
            
            // init all core/global game services (content, data, timer ext)
            
            RegisterViewModels(); // could be overrided
            RegisterDialogViewModels();// could be overrided
            
            
            StartCoroutine(LoadDataServices(gameContainer));
            
        }

        protected override void RegisterViewModels()
        {
            _uiViewModel = new UIGameLoaderViewModel();
            _uiView.Bind(_uiViewModel);
        }
        
        
        private IEnumerator LoadDataServices(DIContainer gameContainer)
        {
            // load saved data or data from server
            _uiViewModel.SetLog("Loading common services");

            yield return new WaitForSeconds(1f);
            
            // load example game data
            var gameDataLoaded = false;
            ExampleGameData gameData = null;
            var dataProvider = new ExampleGameDataProvider("GameData");
            dataProvider.LoadData().Subscribe(x =>
            {
                Debug.Log("Data loaded");
                gameData = x as ExampleGameData;
                gameDataLoaded = gameData != null;
            }).AddTo(_subscriptionBag);
            
            yield return new WaitUntil(() => gameDataLoaded);
            
            
            var _cmdProcessor = new GenericCommandProcessor<ExampleGameData>();
            
            var game = new ExampleGame(gameData);
            var gameService = new ExampleGameService(game, _cmdProcessor);
            gameContainer.Register(_ => gameData);
            gameContainer.Register(_ => gameService);
            
            _uiViewModel.SetLog("End Loading common services");
            
            // init pameplay params
            var gameplayEntryParams = new GameplayEnterParams(_container);
            var gameplayExitParams = new GameplayExitParams("");
            gameContainer.Register(_ => gameplayEntryParams);
            gameContainer.Register(_ => gameplayExitParams);
            // load gameplay scene
            
            var sceneService = gameContainer.Resolve<ScenesService>();
            sceneService.LoadGameplayScene();
        }


        public void Dispose()
        {
            _subscriptionBag?.Dispose();
            _subscriptionBag = new();
        }
    }
}