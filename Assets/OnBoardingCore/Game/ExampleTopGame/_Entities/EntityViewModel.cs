using Lukomor.MVVM;
using Lukomor.Reactive;


namespace OnBoardingCore.Game.ExampleTopGame._Entities
{
    public class EntityViewModel: IViewModel
    {
        
        private int _entity;
        
        public ReactiveProperty<string> Caption => new("Entity");
        public ReactiveProperty<int> Value => _value;
        private ReactiveProperty<int> _value;
        
        public EntityViewModel(int entity)
        {
            _entity = entity;
            _value  =  new(entity);
        }


        
    }
}