using System.Collections.Generic;
using UnityEngine;
using MedievalGame.Model;
using MedievalGame.Enum;
using MedievalGame.Product;

namespace MedievalGame.Player
{
    [RequireComponent(typeof(PlayerControl))]
    public class Player : MonoBehaviour
    {
        public Wealth Wealth => _wealth;
        public Level Level => _level;
        public Experience Experience => _experience;
        public Energy Energy => _energy;
        public Bucket Bucket => _bucket;
        public Items Items => _items;

        [Header("Player characteristics")]
        [SerializeField] private List<SkillType> _skillsList;
        [SerializeField] private int _maxPlayerLevel;
        [SerializeField] private int _maxSkillsLevel;
        [SerializeField] private int _maxEnergyLevel;

        [Header("Player speeds")]
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotationSpeed;

        [Header("Player wealth")]
        [SerializeField] private int _maxGold;
        [SerializeField] private ProductDataBase _productDB;

        private PlayerControl _control;
        private Dictionary<SkillType, Skill> _skills;
        private Wealth _wealth;
        private Level _level;
        private Experience _experience;
        private Energy _energy;
        private Bucket _bucket;
        private Movement _playerMovement;
        private Items _items;

        private void Awake()
        {
            _bucket = new Bucket();
            _control = GetComponent<PlayerControl>();
            _experience = new Experience();
            _energy = new Energy(_maxEnergyLevel);
            _skills = new Dictionary<SkillType, Skill>();
            _skillsList.ForEach(skill => _skills.Add(skill, new Skill(_maxSkillsLevel)));
            _wealth = new Wealth(_maxGold);
            _level = new Level(_maxPlayerLevel);
            _playerMovement = new Movement(_moveSpeed, _rotationSpeed);
            _items = new Items(_productDB);
        }

        private void FixedUpdate()
        {
            _control.Control(_playerMovement);
        }
    }
}

