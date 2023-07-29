using System;
using UniRx;
using Zenject;

namespace Shooter.Gameplay
{
    public class ScorePresenter : IInitializable, IDisposable
    {
        private readonly IScore _score;
        private readonly IScoreView _view;
        private readonly CompositeDisposable _disposable;
        
        public ScorePresenter(IScore score, IScoreView view)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _disposable = new CompositeDisposable();
        }

        public void Initialize()
        {
            _score.Count.Subscribe(OnChanged).AddTo(_disposable);
        }

        private void OnChanged(int count)
        {
            _view.Show(count);
        }
        
        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}