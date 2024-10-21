using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FirstApp
{
    internal class PlayGallow
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine(" .----.");
            Console.WriteLine(" |    |");
            Console.WriteLine(" 0    |");
            Console.WriteLine("/|" + @"\" + "   | ");
            Console.WriteLine("/ " + @"\" + "   | ");
            Console.WriteLine("      |");
            Console.WriteLine("     /_" + @"\");*/

            Console.Write("Привет! Рада, что ты решил поиграть в мою виселицу) Введи слово: " );
            string word = Console.ReadLine();
            Console.Clear();
            string GuessWord = new string('_', word.Length);
            var t = GallowsPicter();
            int currentIndex = 0;
            char letter = ' ';

            Console.WriteLine("Виселица:");
            foreach (var temp in t.Skip(currentIndex++).FirstOrDefault())
            {
                Console.WriteLine(temp);
            }

            while (word != GuessWord)
            {
                
                Console.WriteLine(GuessWord);
                
                do { 
                    try
                    {
                        Console.Write("Ваша буква: ");
                        letter = Convert.ToChar(Console.ReadLine());
                    }
                    catch {
                        letter = ' ';
                    }
                } while (letter == ' ');
                
                

                if (word.Contains(letter) && !GuessWord.Contains(letter))
                {
                    GuessWord = substitute(word,GuessWord,letter);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Виселица:");
                    foreach (var temp in t.Skip(currentIndex++).FirstOrDefault())
                    {
                        Console.WriteLine(temp);
                    }
                    if (currentIndex > 10) {
                        Console.WriteLine("Вы проиграли! ");
                        Thread.Sleep(5000);
                        Environment.Exit(0);
                    }
                   
                } 
                if (GuessWord == word)
                    {
                        Console.WriteLine("Победа! ");
                        Thread.Sleep(5000);
                        Environment.Exit(0);
                    }

            }
        }
        static string substitute(string w,string cw,char l) {
            string result = "";
            for (int i = 0; i < w.Length; i++)
            {
                if (w[i] == l || cw[i]!='_')
                {
                    result += w[i];
                }
                else
                {
                    result += "_";
                }
            }
            return result;
        }
        static IEnumerable<string[]> GallowsPicter()
        {
            string[] Gallow ={ "*************",
                               "*           *",
                               "*           *",
                               "*           *",
                               "*           *",
                               "*           *",
                               "*           *",
                               "*           *",
                               "*************",

             };
            yield return Gallow;

            Gallow[7] = "*       /_" + @"\ *";
            yield return Gallow;

            Gallow = new string[]{
                               "*************",
                               "*           *",
                               "*        |  *",
                               "*        |  *",
                               "*        |  *",
                               "*        |  *",
                               "*        |  *",
                               "*       /_" + @"\ *",
                               "*************",
            };
            yield return Gallow;

            Gallow[1] = "*   .____.  *";
            yield return Gallow;

            Gallow[2] = "*   |    |  *";
            yield return Gallow;

            Gallow[3] = "*   0    |  *";
            yield return Gallow;

            Gallow[4] = "*   |    |  *";
            yield return Gallow;

            Gallow[4] = "*  /|    |  *";
            yield return Gallow;

            Gallow[4] = "*  /|" + @"\" + "   |  *";
            yield return Gallow;

            Gallow[5] = "*  /     |  *";
            yield return Gallow;

            Gallow[5] = "*  / " + @"\" + "   |  *";
            yield return Gallow;
        }
    }
}
