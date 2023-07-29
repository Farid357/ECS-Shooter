using Shooter.Gameplay;
using UnityEngine;
using Zenject;

namespace Shooter.Core
{
    public class StatisticsInstaller : MonoInstaller
    {
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private BestScoreRecordView _recordView;

        public override void InstallBindings()
        {
            IScore score = new Score();
            ScorePresenter scorePresenter = new ScorePresenter(score, _scoreView);
            BestScoreRecord bestScoreRecord = new BestScoreRecord(score);
            BestScoreRecordPresenter scoreRecordPresenter = new BestScoreRecordPresenter(bestScoreRecord, _recordView);
            
            Container.BindInstance(score).AsSingle();

            Container.BindInterfacesTo<ScorePresenter>().FromInstance(scorePresenter).AsSingle();
            Container.BindInterfacesTo<BestScoreRecord>().FromInstance(bestScoreRecord).AsSingle();
            Container.BindInterfacesTo<BestScoreRecordPresenter>().FromInstance(scoreRecordPresenter).AsSingle();
        }
    }
}