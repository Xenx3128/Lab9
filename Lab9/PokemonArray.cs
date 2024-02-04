// Pokemon Array Class

using System;
using Input;

namespace Lab9
{
	public class PokemonArray
	{
		private Pokemon[] arr;  // array of Pokemons
		private static int pokemonArrayCount = 0;  // amount of PokemonArray objects created

		public Pokemon[] Arr  // Array property
		{
			get
			{
				return arr;
			}
			set
			{
				arr = value;
			}
		}

		public Pokemon this[int index]  // PokemonArray indexer
        {
            get
            {
				if (index >= 0 && index < Length)
				{
					return Arr[index];
				}
				throw new IndexOutOfRangeException("Ошибка: индекс вышел за границы массива");
            }
            set
            {
				if (index >= 0 && index < Length)
				{
					Arr[index] = value;
				}
                else
                {
					throw new IndexOutOfRangeException("Ошибка: индекс вышел за границы массива");
				}
			}
        }

		public static int GetCount => pokemonArrayCount;  // returns amount of PokemonArray objects created

		public PokemonArray()  // empty constructor
		{
			Arr = new Pokemon[10];
			for (int i = 0; i < 10; i++)
			{
				Arr[i] = new Pokemon(Pokemon.minAttack, Pokemon.minDefense, Pokemon.minStamina);
			}
			pokemonArrayCount++;
		}
		public PokemonArray(uint size, bool random = true)  // constructor w/ size of array and random or keyboard input
		{
			Arr = new Pokemon[size];
			int atk, def, sta;
			if (random)  // random Pokemon input
            {
				Random rnd = new Random();
				for (int i = 0; i < size; i++)
				{
					atk = rnd.Next(Pokemon.minAttack, Pokemon.maxAttack);
					def = rnd.Next(Pokemon.minDefense, Pokemon.maxDefense);
					sta = rnd.Next(Pokemon.minStamina, Pokemon.maxStamina);
					Arr[i] = new Pokemon(atk, def, sta);

				}
			}
            else  // keyboard Pokemon input
            {
				for (int i = 0; i < size; i++)
				{
					atk = CustomInput.IntInput($"Введите атаку покемона {i + 1} (от {Pokemon.minAttack} до {Pokemon.maxAttack})",
						lowerBoundary: Pokemon.minAttack,
						upperBoundary: Pokemon.maxAttack);
					def = CustomInput.IntInput($"Введите защиту покемона {i + 1} (от {Pokemon.minDefense} до {Pokemon.maxDefense})",
						lowerBoundary: Pokemon.minDefense,
						upperBoundary: Pokemon.maxDefense);
					sta = CustomInput.IntInput($"Введите выносливость покемона {i + 1} (от {Pokemon.minStamina} до {Pokemon.maxStamina})",
						lowerBoundary: Pokemon.minStamina,
						upperBoundary: Pokemon.maxStamina);
					Arr[i] = new Pokemon(atk, def, sta);
				}
			}
			pokemonArrayCount++;

		}
		public PokemonArray(PokemonArray pok)    // copy constructor
		{
			Arr = new Pokemon[pok.Length];
			for(int i = 0; i < Length; i++)
            {
				Arr[i] = new Pokemon(pok[i]);
            }
			pokemonArrayCount++;
		}
		
		public int Length  // returns length of array
        {
			get => Arr.Length;	
        }

		public override bool Equals(object? obj)  // checks if all pokemons in two arrays are equal
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is not PokemonArray)
			{
				return false;
			}
			if (Length != ((PokemonArray)obj).Length)
            {
				return false;
			}
			int cnt = 0;
			for(int i = 0; i < Length; i++)
            {
				if (Equals(this[i], ((PokemonArray)obj)[i]))
                {
					cnt++;
                }
            }
			return cnt == Length;
		}

		public void Show()  // prints PokemonArray summary
		{
			Console.WriteLine("Покемоны:");
			for(int i = 0; i < Length; i++)
            {
				Console.Write($"{i + 1}) ");
				this[i].Show();
            }
			
		}
	}
}