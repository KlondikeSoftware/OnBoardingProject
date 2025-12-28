using com.ksgames.core.architect;

namespace OnBoardingCore.Game.ExampleTopGame._cmd
{
    public class CmdRemoveEntityHandler: ICommandHandler<CmdRemoveEntity>
    {
        private ExampleGame _game;

        public CmdRemoveEntityHandler(ExampleGame game)
        {
            _game = game;
        }

        public bool Handle(CmdRemoveEntity command)
        {
            return _game.Entities.Remove(command.Entity); 
        }
    }
}