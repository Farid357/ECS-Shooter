using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Shooter.Gameplay
{
    public class GamePause : IInitializable, IDisposable
    {
        private readonly ICharacter _character;
        private readonly CompositeDisposable _disposable;

        public GamePause(ICharacter character)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
            _disposable = new CompositeDisposable();
        }

        public void Initialize()
        {
            _character.IsAlive.Subscribe(Pause).AddTo(_disposable);
        }

        private void Pause(bool isCharacterAlive)
        {
            Time.timeScale = isCharacterAlive ? 1 : 0;
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}