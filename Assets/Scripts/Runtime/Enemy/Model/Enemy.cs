using BananaParty.BehaviorTree;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Shooter.Gameplay
{
    public abstract class Enemy : SerializedMonoBehaviour
    {
        private IBehaviorNode _behaviorNode;

        private void OnEnable()
        {
            _behaviorNode = CreateBehavior();
        }

        private void Update()
        {
            _behaviorNode.Execute((long)Time.time * 1000);
            
            if(_behaviorNode.Status == BehaviorNodeStatus.Success)
                _behaviorNode.Reset();
        }

        protected abstract IBehaviorNode CreateBehavior();
    }
}