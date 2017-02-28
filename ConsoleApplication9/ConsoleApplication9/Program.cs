using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            int[] p = new int[100];

            for (i = 0; i < 16; i++)
            {
                p[i] = i + 1;
            }

            p[15] = 0;



            Console.WriteLine("\t *******************");
            Console.Write("\t * ИГРА - ПЯТНАШКИ *" + "\n");
            Console.WriteLine("\t *******************");

         

            Game MyGame = new Game(p);
            int score = 0;
          
            // MyGame.mixer(p);

            for (; ; )
            {
                MyGame.drawField();
               
                Console.WriteLine("Выберите число: ");

                int a=Convert.ToInt32(Console.ReadLine());

               MyGame.Move(a);

                if (MyGame.finish())
                {
                    MyGame.drawField();
                    Console.WriteLine("Вы выиграли!!!!");
                    Console.WriteLine("Конец игры");
                    break;
                }
                score++;

                Console.WriteLine("Количество ходов: " + score);

             
            }
        }

        
    }
}
