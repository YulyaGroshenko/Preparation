using System;
using System.Collections.Generic;
using System.IO;

namespace Виселлица
{                           
    class Program
    {
        static void Main()
        {
            List<char> list = new List<char>();
            string word = WordSelection();
            DrawWord(word, list);
            int attemps = Gaming(word,ref list);            
            Gaming(word,ref list);
            OutputResult(attemps, list);
        }
        static string WordSelection()
        {
            string[] words = File.ReadAllLines("file.txt");
            string word = words[new Random().Next(0, words.Length)];
            return word;
        }
        static void DrawWord(string word, List<char> list)
        {            
            Console.WriteLine($"Длина слова: {word.Length}");                        
            for (int i = 0; i < word.Length; i++)
            {
                list.Add('_');                
                Console.Write(list[i]);
                Console.Write(" ");
            }
        }
        static int Gaming(string word, ref List<char> list)
        {
            int attemps = 5;
            while ((attemps != 0) && (list.Contains('_')))
            {
                Console.WriteLine($"количество попыток: {attemps}");
                string letter = Console.ReadLine();
                if (word.Contains(letter))
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i].ToString() == letter)
                        {
                            list[i] = Convert.ToChar(letter);
                        }
                    }
                    for (int k = 0; k < word.Length; k++)
                    {
                        Console.Write(list[k]);
                        Console.Write(" ");
                    }
                }
                else
                {
                    attemps -= 1;
                }
                                         
            }
            OutputResult(attemps, list);
            return attemps;
            
        }
        static void OutputResult(int attemps, List<char> list)
        {

            if (attemps == 0)
            {
                Console.Clear();
                Console.WriteLine("You lose");
            }
            else if (!list.Contains('_'))
            {
                Console.Clear();
                Console.WriteLine("You win");
            }
        }
    }
}
//Программа загадывает слово и выводит кол-во знаков
//подчеркивания, соответствующее кол-ву букв в слове и кол-во 
//попыток, которые есть у пользователя. Программа ожидает
//введения буквы. Если буква правильная, то она отображается
//вместо знака подчеркивания. Если неправильная, то счетчик
//доступных попыток уменьшается. Если кол-во попыток
//тановится равным нуля, выводится сообщение о проигрыше.
//Если слово полностью отгадано, выводит сообщение о 
//выигрыше.
