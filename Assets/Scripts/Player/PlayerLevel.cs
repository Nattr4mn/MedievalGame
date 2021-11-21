using MedievalGame.Model;
using System;
using UnityEngine;

namespace MedievalGame.Player
{
    public class PlayerLevel : MonoBehaviour
    {
        public Level Level => _level;
        public Experience Experience => _experience;

        [SerializeField] private int _maxPlayerLevel;
        private Level _level;
        private Experience _experience;

        private void Awake()
        {
            _level = new Level(_maxPlayerLevel);
            _experience = new Experience();
        }

        public void ExperienceChange(float experience)
        {
            if(_level.CurrentLevel <= _level.MaxLevel)
            {
                if (_experience.TryExperienceChange(experience))
                {
                    if(_experience.ExperienceIsMax)
                    {
                        LevelUp();
                    }
                }
                else
                {
                    throw new ArgumentException("Incorrect experience value!");
                }
            }
            else
            {
                throw new Exception("Level is max!");
            }
        }

        private void LevelUp()
        {
            _level.TryLevelUp();
            _experience.ResetExperience();
            _experience.SetMaxExperience(_level.CurrentLevel);
        }
    }

    
}
