using System;

namespace MedievalGame.Model
{
    public class Wealth
    {
        public int Gold => _gold;

        private int _gold = 0;
        private int _maxGold;

        public Wealth(int maxGold)
        {
            _maxGold = maxGold;
        }

        public Wealth(int gold, int maxGold)
        {
            _gold = gold;
            _maxGold = maxGold;
        }

        public void GoldQuantityChange(int gold)
        {
            if(_gold >= _maxGold)
            {
                _gold += gold;
            }
            else
            {
                throw new Exception("Gold is max!");
            }
        }
    }
}
