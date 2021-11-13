using System;

namespace MedievalGame.Model
{
    public sealed class Energy
    {
        public float EnergyLevel => _energyLevel;
        public float MaxEnergyLevel => _maxEnergyLevel;

        private float _energyLevel;
        private float _maxEnergyLevel;

        public Energy(float maxEnergyLevel)
        {
            _energyLevel = _maxEnergyLevel = maxEnergyLevel;
        }

        public Energy(float energyLevel, float maxEnergyLevel)
        {
            _energyLevel = energyLevel;
            _maxEnergyLevel = maxEnergyLevel;
        }

        public void EnergyChange(float value)
        {
            if((value > -_maxEnergyLevel && value < _maxEnergyLevel) && (_energyLevel > 0 && _energyLevel < _maxEnergyLevel))
            {
                _energyLevel += value;

                if (_energyLevel < 0)
                    _energyLevel = 0;

                if (_energyLevel > _maxEnergyLevel)
                    _energyLevel = _maxEnergyLevel;
            }
            else
            {
                throw new ArgumentException("Invalid energy value!");
            }
        }
    }
}
