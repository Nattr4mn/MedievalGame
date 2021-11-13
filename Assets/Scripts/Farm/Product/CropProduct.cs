using MedievalGame.Enum;
using MedievalGame.Interface;
using UnityEngine;

namespace MedievalGame.Product
{
    [CreateAssetMenu(menuName = "Product/Crop Product")]
    public class CropProduct : ScriptableObject, IProduct, IItem
    {
        public CropEnum CropType => _cropType;
        public float BasePrice => _basePrice;
        public Sprite ItemSprite => _cropPreviewSprite;

        [SerializeField] private CropEnum _cropType;
        [SerializeField] private float _basePrice = 0f;
        [SerializeField] private Sprite _cropPreviewSprite;
    }
}
