using System.Collections.Generic;
using UnityEngine;
using MedievalGame.Model;
using MedievalGame.Enum;
using MedievalGame.Product;

namespace MedievalGame.Player
{
    [RequireComponent(typeof(PlayerControl))]
    [RequireComponent(typeof(PlayerLevel))]
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerSkills))]
    public class Player : MonoBehaviour
    {
        public Wealth Wealth => _wealth;
        public Energy Energy => _energy;
        public Bucket Bucket => _bucket;
        public Items Items => _items;

        [SerializeField] private int _maxEnergyLevel;
        [SerializeField] private int _maxGold;
        [SerializeField] private ProductDataBase _productDB;

        private PlayerControl _control;
        private PlayerMovement _movement;
        private PlayerLevel _level;
        private PlayerSkills _skills;
        private Energy _energy;
        private Wealth _wealth;
        private Bucket _bucket;
        private Items _items;

        private void Awake()
        {
            _bucket = new Bucket();
            _energy = new Energy(_maxEnergyLevel);
            _wealth = new Wealth(_maxGold);
            _items = new Items(_productDB);
            _control = GetComponent<PlayerControl>();
            _movement = GetComponent<PlayerMovement>();
            _level = GetComponent<PlayerLevel>();
            _skills = GetComponent<PlayerSkills>();
        }

        private void FixedUpdate()
        {
            _control.Control(_movement.Movement);
        }
    }
}

