namespace MedievalGame.Model
{
    public class Experience
    {
        public float CurrentExperience => _experience;
        public bool ExperienceIsMax => _experienceIsMax;

        private float _experience = 0f;
        private float _maxExperience;
        private bool _experienceIsMax = false;

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
                    _experienceIsMax = true;
                }
                return true;
            }

            return false;
        }

        public void ResetExperience()
        {
            _experience -= _maxExperience;
            _experienceIsMax = false;
        }

        public void SetMaxExperience(int playerLevel)
        {
            _maxExperience = 10 + (1 * playerLevel);
        }
    }
}
