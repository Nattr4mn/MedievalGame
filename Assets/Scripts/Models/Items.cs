using MedievalGame.Interface;
using MedievalGame.Product;
using System.Collections.Generic;
using UnityEngine;

namespace MedievalGame.Model
{
    public class Items : MonoBehaviour
    {
        public readonly Dictionary<IProduct, int> _animals;
        public readonly Dictionary<IProduct, int> _meats;
        public readonly Dictionary<IProduct, int> _crops;
        public readonly Dictionary<IProduct, int> _seeds;

        public Items(ProductDataBase productDB)
        {
            _animals = new Dictionary<IProduct, int>();
            _meats = new Dictionary<IProduct, int>();
            _crops = new Dictionary<IProduct, int>();
            _seeds = new Dictionary<IProduct, int>();
            LoadProducts(productDB);
        }

        private void LoadProducts(ProductDataBase _productsDB)
        {
            for(int i = 0; i< _productsDB.Animals.Count; i++)
            {
                _animals.Add(_productsDB.Animals[i], 0);
                _meats.Add(_productsDB.Meats[i], 0);
            }

            for (int i = 0; i < _productsDB.Animals.Count; i++)
            {
                _crops.Add(_productsDB.Crops[i], 0);
                _seeds.Add(_productsDB.Seeds[i], 0);
            }
        }
    }
}
