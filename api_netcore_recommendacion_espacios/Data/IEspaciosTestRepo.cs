using api_netcore_recommendacion_espacios.Modelo;
using System.Collections.Generic;

namespace api_netcore_recommendacion_espacios.Data
{
    public interface IEspaciosTestRepo
    {
        IEnumerable<Espacios_Test> GetAllEspacios();
        Espacios_Test GetEspaciosById(int id);
        public void CreateData();

    }
}
