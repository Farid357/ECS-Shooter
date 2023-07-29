using System;
using System.Collections.Generic;
using SaveSystem;
using SaveSystem.Paths;
using UniRx;
using Zenject;

namespace Shooter.Gameplay
{
    public class BestScoreRecord : IInitializable, IDisposable
    {
        private readonly IScore _score;
        private readonly ISaveStorage<int> _recordStorage;
        private readonly CompositeDisposable _disposable = new();
        private readonly ReactiveProperty<int> _record = new();

        public BestScoreRecord(IScore score)
        {
            _recordStorage = new BinaryStorage<int>(new Path(nameof(BestScoreRecord)));
            _score = score ?? throw new ArgumentNullException(nameof(score));
        }

        public IReadOnlyReactiveProperty<int> Record => _record;

        public void Initialize()
        {
            int record = _recordStorage.HasSave() ? _recordStorage.Load() : 0;
            _record.Value = record;
            _score.Count.Subscribe(OnChanged).AddTo(_disposable);
        }

        private void OnChanged(int score)
        {
            if (_record.Value < score)
                _record.Value = score;
        }
        
        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}