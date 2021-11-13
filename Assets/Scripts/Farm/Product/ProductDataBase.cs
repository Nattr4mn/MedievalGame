using System.Collections.Generic;
using UnityEngine;

namespace MedievalGame.Product
{
    [CreateAssetMenu(menuName = "Product/Product Data Base")]
    public class ProductDataBase : ScriptableObject
    {
        public List<AnimalProduct> Animals;
        public List<MeatProduct> Meats;
        public List<CropProduct> Crops;
        public List<SeedProduct> Seeds;
    }
}
