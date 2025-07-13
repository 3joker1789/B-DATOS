// TorresHanoi/Program.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace TorresHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TORRES DE HANOI");
            Console.WriteLine("---------------");
            Console.Write("Número de discos: ");
            int discos = int.TryParse(Console.ReadLine(), out int n) ? n : 3;
            
            new JuegoHanoi(discos).IniciarResolucion();
        }
    }

    class JuegoHanoi
    {
        private readonly Stack<int>[] torres;
        private int movimientos = 0;
        private readonly int totalDiscos;

        public JuegoHanoi(int discos)
        {
            totalDiscos = discos;
            torres = new[]
            {
                new Stack<int>(),
                new Stack<int>(),
                new Stack<int>()
            };
            
            // Inicializar torre A
            for (int i = discos; i > 0; i--)
                torres[0].Push(i);
        }

        public void IniciarResolucion()
        {
            Console.WriteLine("\nCONFIGURACIÓN INICIAL:");
            MostrarTorres();
            ResolverHanoi(totalDiscos, 0, 2, 1);
            Console.WriteLine($"\n¡SOLUCIÓN COMPLETADA EN {movimientos} MOVIMIENTOS!");
        }

        private void ResolverHanoi(int n, int origen, int destino, int auxiliar)
        {
            if (n <= 0) return;
            
            ResolverHanoi(n - 1, origen, auxiliar, destino);
            
            int disco = torres[origen].Pop();
            torres[destino].Push(disco);
            movimientos++;
            
            Console.WriteLine($"\nMovimiento #{movimientos}: Mover disco {disco} de Torre {(char)('A' + origen)} a Torre {(char)('A' + destino)}");
            MostrarTorres();
            
            ResolverHanoi(n - 1, auxiliar, destino, origen);
        }

        private void MostrarTorres()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Torre {(char)('A' + i)}: {string.Join(", ", torres[i].Reverse())}");
            }
        }
    }
}