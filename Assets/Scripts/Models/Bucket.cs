using UnityEngine;

namespace MedievalGame.Model
{
    public class Bucket
    {
        public float WaterInBucket => _waterInBucket;

        private float _waterInBucket;

        public void FillBucket()
        {
            _waterInBucket = Random.Range(0.5f, 1f);
        }

        public bool TryEmptyTheBucket()
        {
            if (_waterInBucket > 0)
            {
                _waterInBucket = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}