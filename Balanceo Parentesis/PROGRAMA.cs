namespace ConsoleApp1;

public using System;
using System.Collections.Generic;

namespace BalanceoParentesis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("VERIFICACIÓN DE PARÉNTESIS BALANCEADOS");
            Console.WriteLine("-------------------------------------");
            Console.Write("Ingrese una expresión matemática: ");
            string expresion = Console.ReadLine();

            if (EstaBalanceada(expresion))
                Console.WriteLine("\nResultado: Fórmula BALANCEADA");
            else
                Console.WriteLine("\nResultado: Fórmula NO BALANCEADA");

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }

        /// <summary>
        /// Verifica si los paréntesis, llaves y corchetes están balanceados
        /// </summary>
        /// <param name="expresion">Expresión matemática a evaluar</param>
        /// <returns>True si está balanceada, False si no</returns>
        static bool EstaBalanceada(string expresion)
        {
            Stack<char> pila = new Stack<char>();
            
            foreach (char c in expresion)
            {
                // Apilar símbolos de apertura
                if (c == '(' || c == '{' || c == '[')
                {
                    pila.Push(c);
                }
                // Procesar símbolos de cierre
                else if (c == ')' || c == '}' || c == ']')
                {
                    // Si la pila está vacía al encontrar un cierre -> no balanceado
                    if (pila.Count == 0) 
                        return false;
                    
                    char ultimo = pila.Pop();
                    
                    // Verificar correspondencia
                    if ((c == ')' && ultimo != '(') ||
                        (c == '}' && ultimo != '{') ||
                        (c == ']' && ultimo != '['))
                        return false;
                }
            }
            
            // Si quedan elementos en la pila -> no balanceado
            return pila.Count == 0;
        }
    }
} Class1
{
    
}
