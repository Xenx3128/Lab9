// Pokemon class

using System;

namespace Lab9
{

	public class Pokemon
	{
		//  Constants for min/max Pokemon stats
		public const int minAttack = 17;
		public const int maxAttack = 414;
		public const int minDefense = 32;
		public const int maxDefense = 396;
		public const int minStamina = 1;
		public const int maxStamina = 496;

		private int attack;  // from 17 to 414
		private int defense;  // from 32 to 396
		private int stamina;  // from 1 to 496
		private static int pokemonCount = 0;  // amount of created Pokemon objects

		public int Attack  // attack property
        {
            get
            {
				return attack;
            }
            set
            {
				if(value < minAttack)
                {
					attack = minAttack;
					Console.WriteLine("Атака покемона стала ниже минимальной, округляем до минимальной");
				}
				else if (value > maxAttack)
                {
					attack = maxAttack;
					Console.WriteLine("Атака покемона превысила максимальную, округляем до максимальной");
				}
                else
                {
					attack = value;
				}
            }
        }

		public int Defense // defense property
		{
			get
			{
				return defense;
			}
			set
			{
				if (value < minDefense)
				{
					defense = minDefense;
					Console.WriteLine("Защита покемона стала ниже минимальной, округляем до минимальной");
				}
				else if (value > maxDefense)
				{
					defense = maxDefense;
					Console.WriteLine("Защита покемона превысила максимальную, округляем до максимальной");
				}
				else
				{
					defense = value;
				}
			}
		}

		public int Stamina  // stamina property
		{
			get
			{
				return stamina;
			}
			set
			{
				if (value < minStamina)
				{
					stamina = minStamina;
					Console.WriteLine("Выносливость покемона стала ниже минимальной, округляем до минимальной");
				}
				else if (value > maxStamina)
				{
					stamina = maxStamina;
					Console.WriteLine("Выносливость покемона превысила максимальную, округляем до максимальной");
				}
				else
				{
					stamina = value;
				}
			}
		}
		public static int GetCount => pokemonCount;  // returns amount of created Pokemon objects

		public Pokemon()  // empty constructor
		{
			Attack = minAttack;
			Defense = minDefense;
			Stamina = minStamina;
			pokemonCount++;
		}

		public Pokemon(int attack, int defense, int stamina)    // constructor w/ attributes
		{
			Attack = attack;
			Defense = defense;
			Stamina = stamina;
			pokemonCount++;
		}

		public Pokemon(Pokemon pok)    // copy constructor
		{
			Attack = pok.Attack;
			Defense = pok.Defense;
			Stamina = pok.Stamina;
			pokemonCount++;
		}
		public static double operator ~(Pokemon pok)  // returns Pokemon power
		{
			return Math.Round(Math.Sqrt(pok.Stamina) * pok.Attack * Math.Sqrt(pok.Defense) / 10, 2);
		}
		public static Pokemon operator --(Pokemon pok)  // reduces stamina by 1
		{
			pok.Stamina--;
			return pok;
		}
		public static explicit operator int(Pokemon pok)  // returns sum of Pokemon stats
		{
			return pok.Attack + pok.Defense + pok.Stamina;
		}
		public static implicit operator double(Pokemon pok)  // returns the average of Pokemon stats
		{
			return Math.Round((double)(pok.Attack + pok.Defense + pok.Stamina) / 3, 2);
		}

		public static Pokemon operator >>(Pokemon pok, int num)  // Increases stamina by specified amount
		{
			pok.AddStats(0, 0, num);
			return pok;
		}
		public static Pokemon operator >(Pokemon pok, int num)  // Increases defense by specified amount
		{
			pok.AddStats(0, num, 0);
			return pok;
		}
		public static Pokemon operator <(Pokemon pok, int num)  // Increases attack by specified amount
		{
			pok.AddStats(num, 0, 0);
			return pok;
		}
		public Pokemon AddStats(int attack = 0, int defense = 0, int stamina = 0)  // Increases stamina by specified amount
		{
			Attack += attack;
			Defense += defense;
			Stamina += stamina;
			return this;
		}
		public override bool Equals(object? obj) {  // Checks if Pokemons have the same stats
			if (obj == null)
            {
				return false;
            }
			if (obj is not Pokemon)
            {
				return false;
            }
			return Attack == ((Pokemon)obj).Attack &&
				   Defense == ((Pokemon)obj).Defense && 
				   Stamina == ((Pokemon)obj).Stamina;
		}

		public void Show()  // Prints Pokemon stat summary
		{
			Console.WriteLine($"Покемон: Атака: {Attack}; Защита: {Defense}; Выносливость: {Stamina}");
		}
	}	
}
