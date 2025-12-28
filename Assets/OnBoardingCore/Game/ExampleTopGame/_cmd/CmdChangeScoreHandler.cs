using com.ksgames.core.architect;

namespace OnBoardingCore.Game.ExampleTopGame._cmd
{
    public class CmdChangeScoreHandler: ICommandHandler<CmdChangeScore>
    {
        
        private ExampleGame _game;

        public CmdChangeScoreHandler(ExampleGame game)
        {
            _game = game;
        }

        public bool Handle(CmdChangeScore command)
        {
            _game.Score.Value += command.Score;
            return true;
        }
    }
}