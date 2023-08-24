using System;
using BananaParty.BehaviorTree;
using UnityEngine;

namespace Shooter.Gameplay
{
    public class SetAnimatorBoolNode : BehaviorNode
    {
        private readonly Animator _animator;
        private readonly string _boolName;
        private readonly bool _state;

        public SetAnimatorBoolNode(Animator animator, string boolName, bool state)
        {
            _animator = animator ?? throw new ArgumentNullException(nameof(animator));
            _boolName = boolName ?? throw new ArgumentNullException(nameof(boolName));
            _state = state;
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            _animator.SetBool(_boolName, _state);
            return BehaviorNodeStatus.Success;
        }
    }
}