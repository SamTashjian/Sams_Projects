using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroSaga.Data;
using HeroSaga.Models;

namespace HeroSaga
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HeroContext context = new HeroContext())
            {
                Character myCharacter = context.Characters.Find(1);
                Console.WriteLine(myCharacter.Name);
                Console.WriteLine(myCharacter.Age);
                Console.WriteLine(myCharacter.Description);
                Console.WriteLine(myCharacter.Alignment);

                myCharacter.Alignment = Alignment.Chaotic;

                context.Characters.AddOrUpdate(myCharacter);
                context.SaveChanges();

                //Character character = new Character();
                //character.Name = "Randall the Elf Wizard";
                //character.Age = 30;
                //character.Alignment = Alignment.Lawful;
                //character.Description = "Casts spells to breed nerdery over the planet";
                //character.Race = new Race() {Name = "Human"};
                //context.Characters.Add(character);
                //context.SaveChanges();

                Monster monster = new Monster();
                monster.Name = "Ass Nibbler";
                context.Monsters.Add(monster);
                context.SaveChanges();
            }
            Console.ReadLine();
        }
    }
}
