using System;
using System.Collections.Generic;
using SaveSystem;
using SaveSystem.Paths;
using UniRx;
using Zenject;

namespace Shooter.Gameplay
{
    public class WalletPresenter : IInitializable, IDisposable
    {
        private readonly IWallet _wallet;
        private readonly IWalletView _view;
        private readonly ISaveStorage<int> _moneyStorage;
        private readonly CompositeDisposable _disposable = new();

        public WalletPresenter(IWallet wallet, IWalletView view)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _moneyStorage = new BinaryStorage<int>(new Path(nameof(IWallet)));
        }

        public void Initialize()
        {
            int savedMoney = _moneyStorage.HasSave() ? _moneyStorage.Load() : 0;
            _wallet.Put(savedMoney);
            _wallet.Money.Subscribe(OnChanged).AddTo(_disposable);
        }

        private void OnChanged(int money)
        {
            _view.Show(money);
            _moneyStorage.Save(money);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}