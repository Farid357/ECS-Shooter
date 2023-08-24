using System;
using System.Collections.Generic;
using BananaParty.BehaviorTree;
using UnityEngine;
using Random = System.Random;

namespace Shooter.Gameplay
{
    public class PlayRandomAnimationNode : BehaviorNode
    {
        private readonly Animator _animator;
        private readonly Random _random;
        private readonly int[] _animationsId;

        private float _time = -1;
        
        public PlayRandomAnimationNode(Animator animator, IReadOnlyList<string> animations)
        {
            _animator = animator ? animator : throw new ArgumentNullException(nameof(animator));
            _animationsId = new int[animations.Count];
            _random = new Random();
            
            for (int i = 0; i < animations.Count; i++)
            {
                _animationsId[i] = Animator.StringToHash(animations[i]);
            }
        }

        public override BehaviorNodeStatus OnExecute(long time)
        {
            if (_time > 0)
            {
                _time -= Time.deltaTime;
                return _time <= 0 ? BehaviorNodeStatus.Success : BehaviorNodeStatus.Failure;
            }
            
            int randomIndex = _random.Next(0, _animationsId.Length);
            int randomAnimationId = _animationsId[randomIndex];
           
            _animator.Play(randomAnimationId);
            _time = _animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
            return BehaviorNodeStatus.Failure;
        }
    }
}