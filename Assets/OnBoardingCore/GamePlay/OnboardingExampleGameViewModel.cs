using com.ksgames.core.gamecore.topgame.viewmodels;
using Lukomor.Reactive;

namespace OnBoardingCore.Game
{
    public class OnboardingExampleGameViewModel:RootTopGameViewModel
    {
        public ReactiveProperty<string> Caption => _caption;
        private ReactiveProperty<string> _caption;
        
        public OnboardingExampleGameViewModel()
        {
            _caption = new("Example Game View Model");
        }
    }
}