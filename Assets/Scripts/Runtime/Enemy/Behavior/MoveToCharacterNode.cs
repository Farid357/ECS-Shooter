using System;
using BananaParty.BehaviorTree;
using UnityEngine;

namespace Shooter.Gameplay
{
    public class MoveToCharacterNode : BehaviorNode
    {
        private readonly ICharacterSearcher _characterSearcher;
        private readonly IMovement _movement;
        private readonly float _distanceToStopMovement;

        public MoveToCharacterNode(ICharacterSearcher characterSearcher, IMovement movement, float distanceToStopMovement)
        {
            _characterSearcher = characterSearcher ?? throw new ArgumentNullException(nameof(characterSearcher));
            _movement = movement ?? throw new ArgumentNullException(nameof(movement));
            _distanceToStopMovement = distanceToStopMovement;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _characterSearcher.Search();

            if (_characterSearcher.HasFoundCharacter == false)
                return BehaviorNodeStatus.Failure;

            Vector3 difference = _characterSearcher.SearchedCharacter.Position - _movement.Position;
            Vector3 moveDirection = difference.normalized;
           
            _movement.Move(moveDirection);
            return difference.sqrMagnitude <= _distanceToStopMovement * _distanceToStopMovement ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
        }
    }
}