using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
/*namespace asal_sayi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bir sayı girin:");
            int a = Convert.ToInt32(Console.ReadLine());
            int[] asalMi = new int[a];
            int b = (a - 1) / 2;
            int kokB = (int)Math.Sqrt(b);

            for(int i = 0; i < a; i++)
            {
                asalMi[i] = i + 1;
            }
            
            
            Console.WriteLine(2);

            for(int i = 0; i <= kokB; i++)
            {
                
                int j = i;
                while ((i + j + 2 * i * j) <= b) 
                {
                    asalMi[i + j + 2 * i * j] = 0;
                    j++;
                    
                }
                if (asalMi[i]!=0)
                {
                    Console.WriteLine(2 * asalMi[i] + 1);
                }

                *Sonuç---> 11111*
              
            }
            

            Console.ReadKey();
        }
    }
}*/


class Program
{
    static void Main()
    {
        Stopwatch kronometre = new Stopwatch();
            Console.WriteLine("Bir sayi giriniz.");
            int a = Convert.ToInt32(Console.ReadLine());
        kronometre.Start();
            int[] asallar = Sundaram(a);
        
            for (int i = 0; i < asallar.Length; i++) //i < a yapınca out of range exception veriyor neden
            {
            
                Console.WriteLine(asallar[i]);
            }

        kronometre.Stop();
        Console.WriteLine($"Geçen süre: {kronometre.ElapsedMilliseconds} milisaniye");

        Console.ReadLine();
    }

    static int[] Sundaram(int a)
    {
        
        
       
        int n = (a - 1) / 2;
        bool[] asalDegil = new bool[n + 1];

        void AsalAlgoritma1()
        {
            int kokN = (int)Math.Sqrt(n);
            for (int i = 1; i <= kokN; i++)
            {
                for (int j = i; (i + j + 2 * i * j) <= n; j++)
                {
                    asalDegil[i + j + 2 * i * j] = true;
                }
            }
        }
        Thread th1 = new Thread(AsalAlgoritma1);
        

        void AsalAlgoritma2()
        {
            int kokN = (int)Math.Sqrt(n);
            for (int i = kokN/3; i <= kokN/2; i++)
            {
                for (int j = i; (i + j + 2 * i * j) <= n; j++)
                {
                    asalDegil[i + j + 2 * i * j] = true;
                }
            }
        }
        Thread th2 = new Thread(AsalAlgoritma2);
        

        void AsalAlgoritma3()
        {
            int kokN = (int)Math.Sqrt(n);
            for (int i = kokN/2; i <= kokN*3/4; i++)
            {
                for (int j = i; (i + j + 2 * i * j) <= n; j++)
                {
                    asalDegil[i + j + 2 * i * j] = true;
                }
            }
        }
        Thread th3 = new Thread(AsalAlgoritma3);
        

        void AsalAlgoritma4()
        {
            int kokN = (int)Math.Sqrt(n);
            for (int i = kokN*3/4; i <= kokN; i++)
            {
                for (int j = i; (i + j + 2 * i * j) <= n; j++)
                {
                    asalDegil[i + j + 2 * i * j] = true;
                }
            }
        }
        Thread th4 = new Thread(AsalAlgoritma4);
        th1.Start();
        th2.Start();
        th3.Start();
        th4.Start();
        AsalAlgoritma1();
        AsalAlgoritma2();
        AsalAlgoritma3();
        AsalAlgoritma4();

        int asalSayac = 1;
        
             
            for (int i = 1; i <= n; i++) // Kaç asal olduğunu saydır
            {
                if (!asalDegil[i])
                {
                    asalSayac++;
                }
            }
        
        
        
        
        
        int[] asallar = new int[asalSayac];
        asallar[0] = 2;
        
       
            int index = 1; // Asalları yazdır
            for (int i = 1; i <= n; i++)
            {
                if (!asalDegil[i])
                {
                    asallar[index++] = 2 * i + 1;
                }
            }
      
        return asallar;
    }
}








