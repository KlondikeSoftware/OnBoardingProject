using com.ksgames.core.architect;
using Lukomor.Reactive;
using OnBoardingCore.Game.ExampleTopGame._cmd;

namespace OnBoardingCore.Game.ExampleTopGame
{
    public class ExampleGameService
    {
        private ICommandProcessor _cmd;
        
        public ExampleGame Game => _game;
        private ExampleGame _game;
        
        public ReactiveProperty<int> Score => _game.Score;
        public ReactiveCollection<int> Entities => _game.Entities;
        
        
        public ExampleGameService(ExampleGame data, ICommandProcessor cmd)
        {
            _game = data;
            _cmd = cmd;
            
            _cmd.RegisterHandler(new CmdAddEntityHandler(_game));
            _cmd.RegisterHandler(new CmdRemoveEntityHandler(_game));
            _cmd.RegisterHandler(new CmdChangeScoreHandler(_game));
        }

        public void ChangeScore(int value)
        {
            var cmd = new CmdChangeScore(value);
            _cmd.Process(cmd);
        }
        public void AddEntity(int value)
        {
            var cmd = new CmdAddEntity(value);
            _cmd.Process(cmd);
        }
        public void RemoveEntity(int value)
        {
            var cmd = new CmdRemoveEntity(value);
            _cmd.Process(cmd);
        }
        
    }
}