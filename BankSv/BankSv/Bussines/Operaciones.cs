using BankSv.Models;
using BankSv.Service;

namespace BankSv.Bussines
{
    public class Operaciones : IOperaciones
    {
        public int retiro(Acciones acciones)
        {
            return acciones.cant % acciones.multiplo;

        }


    }
}
