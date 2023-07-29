using System;
using UniRx;

namespace Shooter.Gameplay
{
    public class Wallet : IWallet
    {
        private readonly ReactiveProperty<int> _money = new();
        
        public IReactiveProperty<int> Money => _money;
       
        public bool CanTake(int money)
        {
            return Money.Value - money >= 0;
        }

        public void Put(int money)
        {
            _money.Value += money;
        }

        public void Take(int money)
        {
            if (!CanTake(money))
                throw new InvalidOperationException(nameof(CanTake));

            _money.Value -= money;
        }
    }
}