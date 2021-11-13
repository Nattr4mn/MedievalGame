using MedievalGame.Enum;
using MedievalGame.Interface;
using UnityEngine;

namespace MedievalGame.Product
{
    [CreateAssetMenu(menuName = "Product/Seed Product")]
    public class SeedProduct : ScriptableObject, IProduct, IItem
    {
        public SeedEnum MeatType => _seedType;
        public float BasePrice => _basePrice;
        public Sprite ItemSprite => _seedPreviewSprite;

        [SerializeField] private SeedEnum _seedType;
        [SerializeField] private float _basePrice = 0f;
        [SerializeField] private Sprite _seedPreviewSprite;
    }
}
