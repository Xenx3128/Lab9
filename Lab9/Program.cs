using System;
using System.Globalization;

namespace Lab9
{
    public class Program
    {
        public static Pokemon AddStats(Pokemon pok, int attack = 0, int defense = 0, int stamina = 0)
        {
            pok.Attack += attack;
            pok.Defense += defense;
            pok.Stamina += stamina;
			return pok;
		}

		public static double PokemonMode(PokemonArray arr)
        {
			if(arr.Length > 0)
            {
				int[] numArr = new int[arr.Length];
				int[] countArr = new int[arr.Length];
				int index = 0;
				int maxCount = 1;
				for (int i = 0; i < arr.Length; i++)
				{
					int sta = arr[i].Stamina;
					int numCheck = Array.IndexOf(numArr, sta);
					if (numCheck == -1)
					{
						numArr[index] = sta;
						countArr[index] = 1;
						index++;
					}
					else
					{
						countArr[numCheck] += 1;
						if (countArr[numCheck] > maxCount)
						{
							maxCount = countArr[numCheck];
						}
					}
				}
				double summ = 0.0;
				int cnt = 0;
				for (int i = 0; i < numArr.Length; i++)
				{
					if (countArr[i] == maxCount)
					{
						summ += numArr[i];
						cnt++;
					}
				}
				double ans = summ / cnt;
				return Math.Round(ans, 2);
			}
			throw new Exception("Ошибка вычисления моды: длина массива должна быть больше нуля");
        }
        static void Main(string[] args)
        {
			Console.WriteLine("Создание 3-х покемонов: без атрибутов, с атрибутами, копия:");
			Pokemon emptyPoke = new Pokemon();
			Pokemon generalPoke = new Pokemon(50, 100, 150);
			Pokemon copyPoke = new Pokemon(generalPoke);
			emptyPoke.Show();
			generalPoke.Show();
			copyPoke.Show();
			Console.WriteLine("------------------------------------------------------------");
			Console.WriteLine("Добавление атрибутов: метод/функция:");
			generalPoke.AddStats(10, 10, 5);
			AddStats(copyPoke, 20, 30, 50);
			generalPoke.Show();
			copyPoke.Show();
			Console.WriteLine("------------------------------------------------------------");
			Console.WriteLine("Превышение верхней/нижней границы атрибута:");
			generalPoke.AddStats(500, 10, 400);
			AddStats(copyPoke, 20, -500, 50);
			generalPoke.Show();
			copyPoke.Show();
			Console.WriteLine("------------------------------------------------------------");
			Console.Write("Общее число созданных покемонов: ");
			Console.WriteLine(Pokemon.GetCount);
			Console.WriteLine("------------------------------------------------------------");
			Console.Write("Боевая мощь copyPoke: ");
			Console.WriteLine(~copyPoke);
			Console.WriteLine("------------------------------------------------------------");
			Console.WriteLine("Уменьшение выносливости copyPoke на 1: ");
			--copyPoke;
			copyPoke.Show();
			Console.WriteLine("------------------------------------------------------------");
			Console.Write("Сумма всех характеристик generalPoke: ");
			Console.WriteLine((int)generalPoke);
			Console.WriteLine("------------------------------------------------------------");
			Console.Write("Cреднее значение характеристик generalPoke: ");
			Console.WriteLine((double)generalPoke);
			Console.WriteLine("------------------------------------------------------------");
			Console.WriteLine("Другое изменение статистик generalPoke: ");
			generalPoke = generalPoke < 10;
			generalPoke = generalPoke > 10;
			generalPoke = generalPoke >> -10;
			generalPoke.Show();
			Console.WriteLine("------------------------------------------------------------");
			Console.WriteLine("Создание случайного массива покемонов:");
			PokemonArray pokeArray = new PokemonArray(10, true);
			pokeArray.Show();
			Console.WriteLine("------------------------------------------------------------");
			Console.WriteLine("Создание копии массива покемонов:");
			PokemonArray copyPokeArray = new PokemonArray(pokeArray);
			copyPokeArray.Show();
			Console.WriteLine("------------------------------------------------------------");
			Console.WriteLine("Первый элемент массива:");
			pokeArray[0] = new Pokemon(100, 100, 100);
			pokeArray[0].Show();
			try
			{
				pokeArray[12].Show();
			}
			catch (IndexOutOfRangeException e)
            {
				Console.WriteLine(e.Message);
            }
			try
			{
				pokeArray[12] = new Pokemon(100, 100, 100);
			}
			catch (IndexOutOfRangeException e)
			{
				Console.WriteLine(e.Message);
			}
			Console.WriteLine("------------------------------------------------------------");
			Console.WriteLine("Мода массива покемонов:");
			PokemonArray tArray = new PokemonArray(0);
			pokeArray[0].Stamina = 100;
			pokeArray[1].Stamina = 100;
			pokeArray[2].Stamina = 200;
			pokeArray[3].Stamina = 200;
			pokeArray.Show();
			try
            {
				Console.WriteLine(PokemonMode(tArray));
			}
			catch (Exception e)
            {
				Console.WriteLine(e.Message);
            }
			Console.WriteLine(PokemonMode(pokeArray));
			Console.WriteLine("------------------------------------------------------------");
			Console.Write("Количество созданных массивов: ");
			Console.WriteLine(PokemonArray.GetCount);
			Console.WriteLine("------------------------------------------------------------");
			PokemonArray tArr = new PokemonArray();
			PokemonArray expArray = new PokemonArray(10);
			for (int i = 0; i < expArray.Length; i++)
			{
				expArray[i].Attack = Pokemon.minAttack;
				expArray[i].Defense = Pokemon.minDefense;
				expArray[i].Stamina = Pokemon.minStamina;
			}

		}
	}
}
