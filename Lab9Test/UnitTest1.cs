using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab9;

namespace Lab9Test
{
    [TestClass]
    public class TestPokemon
    {
        [TestMethod]
        public void TestEmptyPokemon()
        {
            Pokemon tPoke = new Pokemon();
            Pokemon expPoke = new Pokemon(Pokemon.minAttack, Pokemon.minDefense, Pokemon.minStamina);
            Assert.AreEqual(tPoke, expPoke);
        }
        [TestMethod]
        public void TestCopyPokemon()
        {
            Pokemon expPoke = new Pokemon(100, 150, 200);
            Pokemon tPoke = new Pokemon(expPoke);
            Assert.AreEqual(tPoke, expPoke);
        }
        [TestMethod]
        public void TestPokemonStatsPositiveOverflow()
        {
            Pokemon tPoke = new Pokemon(Pokemon.maxAttack + 50, Pokemon.maxDefense + 30, Pokemon.maxStamina + 10);
            Pokemon expPoke = new Pokemon(Pokemon.maxAttack, Pokemon.maxDefense, Pokemon.maxStamina);
            Assert.AreEqual(tPoke, expPoke);
        }
        [TestMethod]
        public void TestPokemonStatsNegativeOverflow()
        {
            Pokemon tPoke = new Pokemon(-500, -500, -500);
            Pokemon expPoke = new Pokemon(Pokemon.minAttack, Pokemon.minDefense, Pokemon.minStamina);
            Assert.AreEqual(tPoke, expPoke);
        }
        [TestMethod]
        public void TestPokemonAddStatsMethod()
        {
            Pokemon tPoke = new Pokemon(100, 100, 100);
            tPoke.AddStats(10, 20, 30);
            Pokemon expPoke = new Pokemon(110, 120, 130);
            Assert.AreEqual(tPoke, expPoke);
        }
        [TestMethod]
        public void TestPokemonAddStatsMethodOverFlow()
        {
            Pokemon tPoke = new Pokemon(Pokemon.maxAttack - 10, Pokemon.maxDefense - 20, Pokemon.minStamina + 5);
            tPoke.AddStats(15, 30, -20);
            Pokemon expPoke = new Pokemon(Pokemon.maxAttack, Pokemon.maxDefense, Pokemon.minStamina);
            Assert.AreEqual(tPoke, expPoke);
        }
        [TestMethod]
        public void TestPokemonAddStatsFunction()
        {
            Pokemon tPoke = new Pokemon(100, 100, 100);
            Program.AddStats(tPoke, 10, 20, 30);
            Pokemon expPoke = new Pokemon(110, 120, 130);
            Assert.AreEqual(tPoke, expPoke);
        }
        [TestMethod]
        public void TestPokemonAddStatsFunctionOverFlow()
        {
            Pokemon tPoke = new Pokemon(Pokemon.maxAttack - 10, Pokemon.maxDefense - 20, Pokemon.minStamina + 5);
            Program.AddStats(tPoke, 15, 30, -20);
            Pokemon expPoke = new Pokemon(Pokemon.maxAttack, Pokemon.maxDefense, Pokemon.minStamina);
            Assert.AreEqual(tPoke, expPoke);
        }
        [TestMethod]
        public void TestPokemonPowerOperator()
        {
            Pokemon tPoke = new Pokemon(100, 100, 100);
            double tPower = ~tPoke;
            double expPower = 1000.0;
            Assert.AreEqual(tPower, expPower);
        }
        [TestMethod]
        public void TestPokemonIntOperator()
        {
            Pokemon tPoke = new Pokemon(100, 100, 100);
            double tInt = (int)tPoke;
            double expInt = 300;
            Assert.AreEqual(tInt, expInt);
        }
        [TestMethod]
        public void TestPokemonDoubleOperator()
        {
            Pokemon tPoke = new Pokemon(100, 150, 200);
            double tDouble = (double)tPoke;
            double expDouble = 150.0;
            Assert.AreEqual(tDouble, expDouble);
        }
        [TestMethod]
        public void TestPokemonStaminaOperator()
        {
            Pokemon tPoke = new Pokemon(100, 150, 200);
            tPoke = tPoke >> 100;
            double expPoke = new Pokemon(100, 150, 300);
            Assert.AreEqual(tPoke, expPoke);
        }
        [TestMethod]
        public void TestPokemonAttackOperator()
        {
            Pokemon tPoke = new Pokemon(Pokemon.maxAttack - 70, 150, 200);
            tPoke = tPoke < 100;
            double expPoke = new Pokemon(Pokemon.maxAttack, 150, 200);
            Assert.AreEqual(tPoke, expPoke);
        }
        [TestMethod]
        public void TestPokemonDefenseOperator()
        {
            Pokemon tPoke = new Pokemon(100, Pokemon.minDefense + 20, 200);
            tPoke = tPoke > -100;
            double expPoke = new Pokemon(100, Pokemon.minDefense, 200);
            Assert.AreEqual(tPoke, expPoke);
        }
    }
    [TestClass]
    public class TestPokemonArray
    {
        [TestMethod]
        public void TestPokemonArrayEmpty()
        {
            PokemonArray tArray = new PokemonArray();
            PokemonArray expArray = new PokemonArray(10);
            for (int i = 0; i < expArray.Length; i++)
            {
                expArray[i].Attack = Pokemon.minAttack;
                expArray[i].Defense = Pokemon.minDefense;
                expArray[i].Stamina = Pokemon.minStamina;
            }
            Assert.AreEqual(tArray, expArray);
        }
        [TestMethod]
        public void TestPokemonArrayCopy()
        {
            PokemonArray expArray = new PokemonArray();
            PokemonArray tArray = new PokemonArray(expArray);
            Assert.AreEqual(tArray, expArray);
        }
        [TestMethod]
        public void TestPokemonArrayIndex()
        {
            PokemonArray tArray = new PokemonArray();
            tArray[3] = new Pokemon(100, 150, 200);
            tArray[3].AddStats(10, 20, 30);
            Pokemon expPoke = new Pokemon(110, 170, 230);
            Assert.AreEqual(tArray[3], expPoke);
        }
        [TestMethod]
        public void TestPokemonArrayGetIndexOverflow()
        {
            PokemonArray tArray = new PokemonArray();
            int tAtk;
            Assert.ThrowsException<IndexOutOfRangeException>(() => tAtk = tArray[12].Attack);
        }
        [TestMethod]
        public void TestPokemonArraySetIndexOverflow()
        {
            PokemonArray tArray = new PokemonArray();
            Assert.ThrowsException<IndexOutOfRangeException>(() => tArray[12] = (new Pokemon(100, 150, 200)));
        }
        [TestMethod]
        public void TestPokemonArrayLength()
        {
            PokemonArray tArray = new PokemonArray();
            Assert.AreEqual(tArray.Length, 10);
        }
        [TestMethod]
        public void TestPokemonArrayMode1()
        {
            PokemonArray tArray = new PokemonArray();
            Assert.AreEqual(Program.PokemonMode(tArray), 1);
        }
        [TestMethod]
        public void TestPokemonArrayMode2()
        {
            PokemonArray tArray = new PokemonArray(10);
            tArray[0].Stamina = 100;
            tArray[1].Stamina = 100;
            tArray[2].Stamina = 200;
            tArray[3].Stamina = 200;
            tArray[4].Stamina = 101;
            tArray[5].Stamina = 102;
            tArray[6].Stamina = 103;
            tArray[7].Stamina = 104;
            tArray[8].Stamina = 105;
            tArray[9].Stamina = 106;
            Assert.AreEqual(Program.PokemonMode(tArray), 150);
        }
        [TestMethod]
        public void TestPokemonArrayModeEmptyArray()
        {
            PokemonArray tArray = new PokemonArray(0);
            Assert.ThrowsException<Exception>(() => Program.PokemonMode(tArray));
        }
    }
}
