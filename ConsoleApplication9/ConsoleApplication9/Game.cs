using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication9
{
    class Game
    {
    
        int[] point=new int[100];
        public int Length=0;

        public static int[] ArrayText=new int [100];
        const int nw = 4, height = 4;
        int[,] field = new int[nw, height];
        Points[] FieldValue = new Points[100];
         

        public Game(int[] point)
        {
            int ruru = 0;
            string[] file = new string[4];
           Length = TextSCV();
          
            //mixer(ArrayText);

            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < nw; i++)
                {
                    field[j, i] = ArrayText[ruru];
                    FieldValue[ArrayText[ruru]] = new Points(j, i);
                    ruru++;

                }
            }
          
        }

        public void mixer(int[] p)
        {

            int tmp = 0;

            Random rnd = new Random();

            for (int i = 0; i < 16; i++)
            {
                bool isExist = false;
                do
                {
                    isExist = false;
                    tmp = rnd.Next(0, 16);
                    for (int j = 0; j < i; j++)
                    {
                        if (tmp == p[j]) { isExist = true; }
                    }
                }
                while (isExist);
                p[i] = tmp;
            }
        }

        public int this[int x, int y]
        {      
            get
            {
                return field[x, y];
            }
            set
            {
                field[x, y] = value;
            }
        }


        private Points GetLocation(int value)
        {

            return FieldValue[value];
        }


        public void drawField()
        {

            Console.Write("~~~~~~~~~~~~~~~~~~~~~~~~~~~~" + "\n");
            for (int i = 0; i < nw; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Console.Write(field[i, j] + "\t");

                }
                Console.WriteLine();

            }

            Console.Write("~~~~~~~~~~~~~~~~~~~~~~~~~~~~" + "\n");

        }

        public bool repeat(double Length,int[] ArrayText)
        {

            for (int i = 0; i < Length; ++i)
            {
                for (int y = i + 1; y < Length; ++y)
                {
                    if (ArrayText[i] == ArrayText[y])
                    {
                        Console.WriteLine(ArrayText[i] + " ==" + ArrayText[y]);
                        throw new ArgumentException("Числа не должны повторяться! ");
                    }


                }
            }
            return true;
        }

        public Boolean finish()
        {
            bool temp = false;
            int value = 1;
            for (int i = 0; i < nw; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    if (field[i, j] == value)
                    {

                        temp = true;
                        ++value;
                        if (value == Length)
                        {
                            value = 0;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }

            }      
            return temp;

        }

        public void Move(int value)
        {

            try
            {
            Console.WriteLine(value);
            if (value > 15 || value < 0)
            {
                throw new ArgumentException();
            }

            int x = GetLocation(0).x;
            int y = GetLocation(0).y;

            int ValueX = GetLocation(value).x;
            int ValueY = GetLocation(value).y;

                if ((ValueX == x && (ValueY == y - 1 || ValueY == y + 1))||(ValueY == y && (ValueX == x - 1 || ValueX == x + 1)))
                {

                    field[x, y] = value;
                    field[ValueX, ValueY] = 0;

                    var vere = FieldValue[0];
                    FieldValue[0] = FieldValue[value];
                    FieldValue[value] = vere;
                }

                else
                {
                    throw new Exception();
                    //Console.WriteLine("Некуда двигать. ");
                }
            }

            catch (ArgumentException)
            {
                Console.WriteLine("Такого числа не существует, попробуйте еще раз: ");
            }
            catch (Exception)
            {
                Console.WriteLine("Рядом с этим числом нету 0, попробуйте еще раз: ");
            }
            
        }

        public static int TextSCV()
        {
            int ruru = 0;
            try
           {
                string[] text = File.ReadAllLines(@"C:\Users\сергей\Desktop\TriangleGit\Switty\ConsoleApplication9\ConsoleApplication9\text.csv");
                Char place = ' ';
              
                for (int i = 0; i < text.Length; ++i)
                {
                    string[] row = text[i].Split(place);
                    foreach (var substring in row)
                    {
                        ArrayText[ruru] = Convert.ToInt32(substring);
                        //Console.WriteLine(ArrayText[ruru]);
                        ++ruru;
                    }
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
               Console.WriteLine(e.Message);
            }
            return ruru;
        }
    }
}
