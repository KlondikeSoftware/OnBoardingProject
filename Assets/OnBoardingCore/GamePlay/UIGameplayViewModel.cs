using Lukomor.MVVM;
using Lukomor.Reactive;

namespace OnBoardingCore.GamePlay
{
    public class UIGameplayViewModel: IViewModel
    {
        private ReactiveProperty<string> _caption;
        public ReactiveProperty<string> Caption => _caption;
    }
}