using System;
using Scellecs.Morpeh;
using StarterAssets;
using UnityEngine;
using Zenject;

namespace Shooter.Gameplay
{
    public class WeaponPickup : MonoBehaviour
    {
        [SerializeField] private WeaponFactory _weaponFactory;
     
        private IWeaponry _weaponry;

        [Inject]
        public void Init(IWeaponry weaponry)
        {
            _weaponry = weaponry ?? throw new ArgumentNullException(nameof(weaponry));
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out FirstPersonController _))
            {
                Entity entity = _weaponFactory.Create();
               
                ref WeaponComponent weaponComponent = ref entity.GetComponent<WeaponComponent>();
                ref WeaponTypeComponent typeComponent = ref entity.GetComponent<WeaponTypeComponent>();
                ref ClipComponent clipComponent = ref entity.GetComponent<ClipComponent>();
            
                weaponComponent.IsSelected = true;
                _weaponry.Add(clipComponent.MaxBullets, typeComponent.GeneralType);
              
                Destroy(gameObject);
            }
        }
    }
}