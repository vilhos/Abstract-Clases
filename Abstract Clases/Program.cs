using System;
using System.Collections.Generic;

namespace WarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Warrior> warriors = new List<Warrior>();
            warriors.Add(new Knight(3, 100, 20));
            warriors.Add(new Archer(2, 80, 15));
            Player player = new Player(4, 300, 25);
            player.Atack(warriors[0]);
            warriors[0].Atack(player);

            player.Atack(warriors[1]);
            warriors[1].Atack(player);
            player.Atack(warriors[1]);
            Console.ReadKey();
        }
    }

    public abstract class Warrior
    {
        protected int Health;
        protected int Durability;
        public int Damage;
        public bool IsAlive { get; set; }

        public Warrior(int health, int durability, int damage)
        {
            Health = health;
            Durability = durability;
            Damage = damage;
        }
        public virtual void TakeDamage(Warrior warrior)
        {
            warrior.Durability -= Damage;
            if (warrior.Durability <= 0)
            {
                warrior.Health -= 1;
                if (warrior.Health == 0)
                    warrior.IsAlive = false;
            }
        }
        public abstract void Atack(Warrior warrior);

        protected void CurrentState()
        {
            Console.WriteLine($"{GetType()} Health: {Health}, Durability: {Durability}, Damage: {Damage}");
        }
    }

    public class Knight : Warrior
    {
        public Knight(int health, int durability, int damage) : base(health, durability, damage)
        {
            IsAlive = true;
        }
        public override void TakeDamage(Warrior warrior)
        {
            base.TakeDamage(warrior);
        }

        public override void Atack(Warrior warrior)
        {
            TakeDamage(warrior);
            CurrentState();
        }
    }

    public class Archer : Warrior
    {
        public Archer(int health, int durability, int damage) : base(health, durability, damage)
        {
            IsAlive = true;
        }
        public override void TakeDamage(Warrior warrior)
        {
            base.TakeDamage(warrior);
        }

        public override void Atack(Warrior warrior)
        {
            TakeDamage(warrior);
            CurrentState();
        }
    }

    public class Player : Warrior
    {
        public Player(int health, int durability, int damage) : base(health, durability, damage)
        {

        }

        public override void Atack(Warrior warrior)
        {
            TakeDamage(warrior);
            CurrentState();
        }
    }
}
