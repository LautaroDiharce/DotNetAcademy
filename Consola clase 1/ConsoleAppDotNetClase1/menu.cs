using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppDotNetClase1
{
    class menu
    {
        public void main()
        {
            bool key = true;
            while (key)
            {
                Console.WriteLine("ingrese una opcion");
                Console.WriteLine("A: Lista de impares entre 0 y 100");
                Console.WriteLine("B: Numeros naturales entre 2 valores pasados coo parametro + conteo de pares");
                Console.WriteLine("C: Vocales en frase de menos de 20 caraacteres");
                Console.WriteLine("D: Tipos de triangulo");
                Console.WriteLine("E: Multiplos de 2 y 3");
                Console.WriteLine("Q: Salir");

                string op = Console.ReadLine().ToLower();
                switch (op)
                {
                    case "a":
                        PuntoA();
                        break;
                    case "b":
                        PuntoB();
                        break;
                    case "c":
                        PuntoC();
                        break;
                    case "d":
                        PuntoD();
                        break;
                    case "e":
                        PuntoE();
                        break;
                    case "q":
                        key = false;
                        break;
                    default:
                        break;
                }
            }

        }
        public void PuntoA()
        {
            List<int> imp = new List<int>();
            imp = Impares(imp);
            Console.WriteLine("listado de impares:");
            for (int i = 0; i < imp.Count; i++)
            {
                Console.WriteLine(imp[i]);
            }
        }
        public List<int> Impares(List<int> lista)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i == 1 || i % 2 != 0)
                {
                    lista.Add(i);
                }
            }
            return lista;
        }

        public void PuntoB()
        {
            Console.WriteLine("ingrese un numero");
            int primero = int.Parse(Console.ReadLine());
            Console.WriteLine("ingrese otro numero");
            int segundo = int.Parse(Console.ReadLine());
            List<int> naturales = GenerarNat(primero, segundo);
            Console.WriteLine("Listado de numeros pares:");
            for (int i = 0; i < naturales.Count; i++)
            {
                Console.WriteLine(naturales[i]);
            };
            Console.WriteLine("Cantidad de numeros naturales");
            Console.WriteLine(naturales.Count);
            int pares = Pares(naturales);
            Console.WriteLine("Cantidad de numeros pares");
            Console.WriteLine(pares);
        }

        public List<int> GenerarNat(int pri, int sec)
        {
            List<int> naturales = new List<int>();
            if (pri == sec)
            {
                naturales.Add(pri);
            }
            else
            {
                if (pri < sec)
                {
                    for (int i = pri; i <= sec; i++)
                    {
                        naturales.Add(i);
                    }
                }
                else
                {
                    for (int i = sec; i <= pri; i++)
                    {
                        naturales.Add(i);
                    }
                }
            }
            return naturales;
        }

        public int Pares(List<int> lista)
        {
            int pares = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] == 0 || lista[i] % 2 == 0)
                {
                    pares ++;
                }
            }
            return pares;
        }
        public void PuntoC()
        {
            Console.WriteLine("ingrese una fase con no mas de 20 caracteres");
            string cadena = Console.ReadLine().ToLower();
            if (ComprobarLongitud(cadena))
            {
                int vocales = ContarVocales(cadena);
                Console.WriteLine("numero de vocales:"+ vocales);
            }
            else
            {
                Console.WriteLine("La cadena ingresada es muy larga");
            }
        }

        public bool ComprobarLongitud(string cadena)
        {

            int largo = cadena.Length;
            if (largo <= 20 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int ContarVocales(string cadena)
        {
            int total = 0;
            var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            for (int i = 0; i < cadena.Length; i++)
            {
                if (vowels.Contains(cadena[i]))
                {
                    total++;
                }
            }
            return total;
        }
        public void PuntoD()
        {
            Console.WriteLine("ingrese un lado:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("ingrese otro lado:");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("ingrese el ultimo lado:");
            int c = int.Parse(Console.ReadLine());
            string resultado = CheckTriangulo(a,b,c);
            Console.WriteLine("El triangulo conformado es: " +resultado);

        }

        public string CheckTriangulo(int a, int b, int c)
        {
            string resultado;
            if (a+b<c || a+c<b||b+c<a)
            {
                resultado = "No es un triangulo";
            }
            else
            {
                if (a==b&&a==c)
                {
                    resultado = "equilatero";
                }
                else
                {
                    if ((a == b && a != c) || (c == b && a != c)|| (a == c && a != b))
                    {
                        resultado = "isosceles";
                    }
                    else
                    {
                        resultado = "escaleno";
                    }
                }
            }
            return resultado;
        }
        public void PuntoE()
        {
            Console.WriteLine("Multiplos de 2 & 3:");
            for (int i = 0; i <= 100; i++)
            {
                if (i%2==0 && i%3==0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
