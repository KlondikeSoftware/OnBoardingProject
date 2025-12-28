using System;
using com.ksgames.core.gamecore.sceneservice.sceneentrypoint;
using Lukomor.DI;
using Lukomor.MVVM;
using OnBoardingCore.Game;
using OnBoardingCore.Game.ExampleTopGame;
using UnityEngine;

namespace OnBoardingCore.GamePlay
{
    public class OnboardingGameplayEntryPoint: SceneEntryPoint, IDisposable
    {
        
        // example //
        
        [Header("Example Game View")]
        public View ExampleGameView; 
        
        public override void Process(DIContainer gameContainer)
        {
            base.Process(gameContainer);
            
            // init all core/global game services (content, data, timer ext)
            RegisterDialogViewModels();// could be overrided
            RegisterViewModels(); // could be overrided
            
            // _message — global message bus for exchanging messages
            // between the upper, middle, and lower parts of the game
            // You can create your own version of _message based on the IMessageBus interface
        }

        protected override void RegisterViewModels()
        {
            base.RegisterViewModels();

            var exampleGameService = _container.Resolve<ExampleGameService>();
            var exampleGameViewModel = new OnboardingExampleGameViewModel(exampleGameService);
            ExampleGameView.Bind(exampleGameViewModel);
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}