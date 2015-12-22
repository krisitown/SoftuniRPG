using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softuni_RPG.Map_and_World;
using Softuni_RPG.GameObjects.Entities;

namespace Softuni_RPG.Entities
{
    class CombatManager
    {
        private readonly Player _player;
        private readonly List<Enemy> _enemies;

        public CombatManager(Player player, List<Enemy> enemies)
        {
            _player = player;
            _enemies = enemies;
        }

        public void Attack(Entity attacker, Entity defender)
        {
            if (attacker.Attack >= defender.Defence)
            {
                double damage = attacker.Attack;

                defender.HP -= damage;

                Trace.WriteLine($"{attacker.Name} hit {defender.Name} for {damage} and he has {defender.HP} health remaining.");

                if (defender.HP <= 0)
                {
                    if (defender is Enemy)
                    {
                        var enemy = defender as Enemy;

                        _enemies.Remove(enemy);
                    }
                    Trace.WriteLine($"{attacker.Name} killed {defender.Name}");
                }
            }
            else
            {
                Trace.WriteLine($"{attacker.Name} missed {defender.Name}");
            }
        }


        public Entity EntityAt(int x, int y)
        {
            if (IsPlayerAt(x, y))
            {
                return _player;
            }
            return EnemyAt(x, y);
        }


        public bool IsPlayerAt(int x, int y)
        {
            return (_player.X == x && _player.Y == y);
        }


        public Enemy EnemyAt(int x, int y)
        {
            foreach (var enemy in _enemies)
            {
                if (enemy.X == x && enemy.Y == y)
                {
                    return enemy;
                }
            }
            return null;
        }

        public bool IsEnemyAt(int x, int y)
        {
            return EnemyAt(x, y) != null;
        }
    }
}