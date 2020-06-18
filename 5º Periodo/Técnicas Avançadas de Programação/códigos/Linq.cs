using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class Carro
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public Carro(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
        }
    }

    class Program
    {
        static void Main()
        {
            List<Carro> carros = new List<Carro>();
            carros.Add(new Carro("Fiat", "Palio"));
            carros.Add(new Carro("Fiat", "Uno"));
            carros.Add(new Carro("Fiat", "Mobi"));
            carros.Add(new Carro("Volkswagen", "Gol"));
            carros.Add(new Carro("Volkswagen", "Fox"));
            carros.Add(new Carro("Volkswagen", "Up!"));
            carros.Add(new Carro("Ford", "Ka"));
            carros.Add(new Carro("Ford", "Fiesta"));
            carros.Add(new Carro("Ford", "Focus"));
            carros.Add(new Carro("Chevrolet", "Celta"));
            carros.Add(new Carro("Chevrolet", "Onix"));
            carros.Add(new Carro("Chevrolet", "Cobalt"));

            //foreach (Carro carro in carros)
               // Console.WriteLine(carro.Marca + " - " + carro.Modelo);

            /*var query = from c in carros
                        where c.Marca.StartsWith("F")
                        orderby c.Modelo
                        select c.Modelo.ToUpper();

            foreach (var carro in query)
             Console.WriteLine(carro);*/

            var query = from c in carros
                        group c by new { c.Marca } into CarrosAgrupados
                        select new {
                            CarrosAgrupados.Key.Marca,
                            Qtd = CarrosAgrupados.Count()
                        };          

            foreach (var carro in query)
                Console.WriteLine(carro.Marca +" - "+ carro.Qtd);


            Console.ReadKey();
        }
    }
}
