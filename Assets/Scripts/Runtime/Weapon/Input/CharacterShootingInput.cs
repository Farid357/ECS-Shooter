using UnityEngine.InputSystem;

namespace Shooter.Gameplay
{
    public class CharacterShootingInput : ICharacterShootingInput
    {
        public bool IsShootingBurst => Mouse.current.leftButton.wasPressedThisFrame;

        public bool IsShooting => Mouse.current.leftButton.isPressed;

    }
}