using com.ksgames.core.architect;

namespace OnBoardingCore.Game.ExampleTopGame._cmd
{
    public class CmdAddEntity: ICommand
    {
        public int Entity => _entity;
        private int _entity;
        
        public CmdAddEntity(int entity)
        {
            _entity = entity;
        }
    }
}