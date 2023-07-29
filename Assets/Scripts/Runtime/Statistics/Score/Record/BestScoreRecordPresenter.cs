using System;
using SaveSystem;
using SaveSystem.Paths;
using UniRx;
using Zenject;

namespace Shooter.Gameplay
{
    public class BestScoreRecordPresenter : IInitializable, IDisposable
    {
        private readonly IBestScoreRecordView _view;
        private readonly BestScoreRecord _bestScore;
        private readonly CompositeDisposable _disposable = new();
        
        public BestScoreRecordPresenter(BestScoreRecord record, IBestScoreRecordView view)
        {
            _bestScore = record ?? throw new ArgumentNullException(nameof(record));
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }
        
        public void Initialize()
        {
            _bestScore.Record.Subscribe(OnChanged).AddTo(_disposable);
        }

        private void OnChanged(int record)
        {
            _view.Show(record);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}