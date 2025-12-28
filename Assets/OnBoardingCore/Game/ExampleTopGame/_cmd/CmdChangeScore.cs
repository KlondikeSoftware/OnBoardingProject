using com.ksgames.core.architect;

namespace OnBoardingCore.Game.ExampleTopGame._cmd
{
    public class CmdChangeScore: ICommand
    {
        public int Score => _score;
        private int _score;
        
        public CmdChangeScore(int score)
        {
            _score = score;
        }
        
    }
}