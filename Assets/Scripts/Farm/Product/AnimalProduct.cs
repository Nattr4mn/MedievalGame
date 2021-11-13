using MedievalGame.Enum;
using MedievalGame.Interface;
using UnityEngine;

namespace MedievalGame.Product
{
    [CreateAssetMenu(menuName = "Product/Animal Product")]
    public class AnimalProduct : ScriptableObject, IProduct, IItem
    {
        public AnimalEnum AnimalType => _animalType;
        public float BasePrice => _basePrice;
        public Sprite ItemSprite => _animalPreviewSprite;

        [SerializeField] private AnimalEnum _animalType;
        [SerializeField] private float _basePrice = 0f;
        [SerializeField] private Sprite _animalPreviewSprite;
    }
}
