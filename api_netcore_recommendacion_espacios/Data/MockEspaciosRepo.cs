using api_netcore_recommendacion_espacios.Modelo;
using System.Collections.Generic;

namespace api_netcore_recommendacion_espacios.Data
{
    public class MockEspaciosRepo : IEspaciosTestRepo
    {
        private List<Espacios_Test> espacios;
        public IEnumerable<Espacios_Test> GetAllEspacios()
        {
            return espacios;
        }

        public Espacios_Test GetEspaciosById(int id)
        {
            for ( int i = 0; i < espacios.Count; i++ )
            {
                if (espacios[i].Id == id)
                {
                    return espacios[i];
                }
            }
            return null;    
        }

        public void CreateData ()
        {
            espacios = new List<Espacios_Test>
            {
                new Espacios_Test { Id = 0000, 
                    Name = "Eduardo Martinez 505",
                    Desc = "Edificio Universidad Prueba",
                    X = 56.435,
                    Y = 23.646},
                new Espacios_Test { Id = 0001,
                    Name = "Matematicas 202",
                    Desc = "Edificio Universidad Prueba",
                    X = 53.128,
                    Y = 21.989},
                new Espacios_Test { Id = 0002,
                    Name = "Física 2102",
                    Desc = "Edificio Universidad Prueba",
                    X = 50.001,
                    Y = 28.109}
            };
        }
    }
}
