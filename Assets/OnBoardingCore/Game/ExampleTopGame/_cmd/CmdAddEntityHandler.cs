using com.ksgames.core.architect;

namespace OnBoardingCore.Game.ExampleTopGame._cmd
{
    public class CmdAddEntityHandler: ICommandHandler<CmdAddEntity>
    {
        private ExampleGame _game;

        public CmdAddEntityHandler(ExampleGame game)
        {
            _game = game;
        }

        public bool Handle(CmdAddEntity command)
        {
            _game.Entities.Add(command.Entity);
            return true;
        }
    }
}