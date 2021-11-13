namespace MedievalGame.Model
{
    public class Level
    {
        public int CurrentLevel => _level;
        public int MaxLevel => _maxLevel;

        private int _level;
        private int _maxLevel;

        public Level(int maxLevel)
        {
            _maxLevel = maxLevel;
        }

        public Level(int level, int maxLevel)
        {
            _level = level;
            _maxLevel = maxLevel;
        }

        public bool TryLevelUp()
        {
            if (_level != _maxLevel)
            {
                _level++;
                return true;
            }

            return false;
        }

    }
}
