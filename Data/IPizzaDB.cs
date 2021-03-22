using Model;
using System.Collections.Generic;

namespace Data
{
    public interface IPizzaDB
    {

        void Insert(Pizza pizza);

        void Delete(Pizza pizza);

        void Updade(Pizza pizza);

        List<Pizza> SelectById(int id);

        List<Pizza> Select();


    }
}