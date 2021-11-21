using MedievalGame.Enum;
using MedievalGame.Model;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    [SerializeField] private List<SkillType> _skillsList;
    [SerializeField] private int _maxSkillsLevel;
    private Dictionary<SkillType, Skill> _skills;

    private void Awake()
    {
        _skills = new Dictionary<SkillType, Skill>();
        _skillsList.ForEach(skill => _skills.Add(skill, new Skill(_maxSkillsLevel)));
    }
}
