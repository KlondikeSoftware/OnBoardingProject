using System.Collections;
using com.ksgames.core.gamecore;
using com.ksgames.core.gamecore.sceneservice;
using com.ksgames.core.gamecore.sceneservice.sceneentrypoint;
using com.ksgames.core.gamecore.sceneservice.viewmodels;
using Lukomor.DI;
using UnityEngine;

namespace OnBoardingCore.GameLoader
{
    public class OnboardingGameLoaderEntryPoint: SceneEntryPoint
    {
        new UIGameLoaderViewModel _uiViewModel;
        
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
    }
}