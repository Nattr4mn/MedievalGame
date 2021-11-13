namespace MedievalGame.Model
{
    public class Experience
    {
        public float CurrentExperience => _experience;

        private float _experience = 0f;
        private float _maxExperience;

        public Experience() { }

        public Experience(float experience, int playerLevel) 
        {
            _experience = experience;
            SetMaxExperience(playerLevel);
        }

        public bool TryExperienceChange(float experience)
        {
            if (experience > 0)
            {
                _experience += experience;
                if (_experience >= _maxExperience)
                {
                    _experience -= _maxExperience;
                    return true;
                }
            }

            return false;
        }

        public void SetMaxExperience(int playerLevel)
        {
            _maxExperience = 10 + (1 * playerLevel);
        }
    }
}
