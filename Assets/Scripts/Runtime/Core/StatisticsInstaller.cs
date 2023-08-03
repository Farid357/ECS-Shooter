using Shooter.Gameplay;
using UnityEngine;
using Zenject;

namespace Shooter.Core
{
    public class StatisticsInstaller : MonoInstaller
    {
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private BestScoreRecordView _recordView;
        [SerializeField] private WalletView _walletView;
        
        public override void InstallBindings()
        {
            IScore score = new Score();
            IWallet wallet = new Wallet();
            
            ScorePresenter scorePresenter = new ScorePresenter(score, _scoreView);
            WalletPresenter walletPresenter = new WalletPresenter(wallet, _walletView);
            BestScoreRecord bestScoreRecord = new BestScoreRecord(score);
            BestScoreRecordPresenter scoreRecordPresenter = new BestScoreRecordPresenter(bestScoreRecord, _recordView);
            
            Container.Bind<IScore>().FromInstance(score).AsSingle();
            Container.Bind<IWallet>().FromInstance(wallet).AsSingle();
            
            Container.BindInterfacesTo<ScorePresenter>().FromInstance(scorePresenter).AsSingle();
            Container.BindInterfacesTo<BestScoreRecord>().FromInstance(bestScoreRecord).AsSingle();
            Container.BindInterfacesTo<WalletPresenter>().FromInstance(walletPresenter).AsSingle();
            Container.BindInterfacesTo<BestScoreRecordPresenter>().FromInstance(scoreRecordPresenter).AsSingle();
        }
    }
}