using BananaParty.BehaviorTree;
using UnityEngine;

namespace Shooter.Gameplay
{
    public class EnemyWarrior : Enemy
    {
        [SerializeField] private IMovement _movement;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _distanceToBeNearCharacter;
        [SerializeField] private float _distanceToStopMovement = 1.5f;
        [SerializeField] private int _attackDamage = 10;
        [SerializeField] private string[] _attackAnimations;

        protected override IBehaviorNode CreateBehavior()
        {
            ICharacterSearcher characterSearcher = new CharacterSearcher(transform, _distanceToBeNearCharacter);

            return new SequenceNode(new IBehaviorNode[]
            {
              //  new WaitNode(2000),
                new RepeatNode(new SequenceNode(new IBehaviorNode[]
                {
                    new IsCharacterNearNode(characterSearcher),
                    new MoveToCharacterNode(characterSearcher, _movement, _distanceToStopMovement),
                    new PlayRandomAnimationNode(_animator, _attackAnimations),
                    new AttackNode(characterSearcher, _attackDamage),
                    new WaitNode(1500)
                })),
            });
        }
    }
}