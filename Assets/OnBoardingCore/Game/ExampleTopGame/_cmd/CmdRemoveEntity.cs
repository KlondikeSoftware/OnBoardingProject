using com.ksgames.core.architect;

namespace OnBoardingCore.Game.ExampleTopGame._cmd
{
    public class CmdRemoveEntity: ICommand
    {
        public int Entity => _entity;
        private int _entity;
        
        public CmdRemoveEntity(int entity)
        {
            _entity = entity;
        }
        
    }
}