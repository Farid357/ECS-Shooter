using System;
using BananaParty.BehaviorTree;
using Scellecs.Morpeh;

namespace Shooter.Gameplay
{
    public class AttackNode : BehaviorNode
    {
        private readonly ICharacterSearcher _characterSearcher;
        private readonly int _damage;

        public AttackNode(ICharacterSearcher characterSearcher, int damage)
        {
            _characterSearcher = characterSearcher ?? throw new ArgumentNullException(nameof(characterSearcher));
            _damage = damage;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _characterSearcher.Search();

            if (!_characterSearcher.HasFoundCharacter)
                return BehaviorNodeStatus.Failure;

            ICharacter character = _characterSearcher.SearchedCharacter;
            ref HealthComponent healthComponent = ref character.Entity.GetComponent<HealthComponent>();
            healthComponent.Health -= _damage;
            return BehaviorNodeStatus.Success;
        }
    }
}