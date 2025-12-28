using System;
using Lukomor.Reactive;
using R3;

namespace OnBoardingCore.Game.ExampleTopGame
{
    // proxy clasee for Example Game Data
    public class ExampleGame: IDisposable
    {
        private ExampleGameData _data;

        public ExampleGameData Data => _data;
        public Lukomor.Reactive.ReactiveProperty<int> Score => _score;
        private Lukomor.Reactive.ReactiveProperty<int> _score;

        public ReactiveCollection<int> Entities => _entities;
        private ReactiveCollection<int> _entities;


        private CompositeDisposable _subscriptions  = new();


        public ExampleGame(ExampleGameData data)
        {
            _data = data;

            _score = new(_data.Score);
            _entities = new(_data.Entities);

            
            // update data on change
            _score.Subscribe(x => { _data.SetScore(x); }).AddTo(_subscriptions);
            _entities.Added.Subscribe(x => { _data.Entities.Add(x); });
            _entities.Removed.Subscribe(x => { _data.Entities.Remove(x);});
        }

        public void Dispose()
        {
            _subscriptions?.Dispose();
            _subscriptions = new();
        }
    }
}