using System.Linq;
using Common;
using Level.Model;
using Level.Other;
using UnityEngine;

namespace Level.Command
{
    public class CheckEntityCollisionCommand : ICommand
    {
        private readonly LevelModel _levelModel;
        private readonly EntityType _type;
        private readonly string _id;
        private readonly Collision2D _collision;

        public CheckEntityCollisionCommand(LevelModel levelModel, EntityType type,
            string id, Collision2D collision)
        {
            _levelModel = levelModel;
            _type = type;
            _id = id;
            _collision = collision;
        }
        
        public void Execute()
        {
            if (_type == EntityType.Bullet)
            {
                _levelModel.BulletPoolModel.SetElementActive(_id, false);
            }
            else if (_type == EntityType.Enemy || _type == EntityType.SmallAsteroid ||
                     _type == EntityType.BigAsteroid)
            {
                var damagable = _collision.transform.GetComponent<IDamagable>();
                if (damagable == null) return;
                var addHealthCommand 
                    = new AddHealthCommand(_levelModel, _type, _id, -damagable.Damage);
                addHealthCommand.Execute();
            }
        }
    }
}