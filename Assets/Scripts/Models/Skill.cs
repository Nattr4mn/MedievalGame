using MedievalGame.Enum;

namespace MedievalGame.Model
{
    public sealed class Skill : Level
    {
        public SkillType SkillType => _skill;

        private SkillType _skill;

        public Skill(int maxLevel) : base(maxLevel) { }

        public Skill(int level, int maxLevel) : base(level, maxLevel) { }
    }
}
