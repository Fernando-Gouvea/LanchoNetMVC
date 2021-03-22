using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Data
{
    public class PizzaDB : IPizzaDB
    {
        private ConnectionDB conn;

        public void Insert(Pizza pizza)
        {
            string sql = string.Format("INSERT INTO Refeicao VALUES('"+pizza.Descricao+"',"+pizza.Valor+");");
            conn = new ConnectionDB();
            conn.ExecQuery(sql);
        }

        public void Updade(Pizza pizza)
        {
            string sql = string.Format("UPDATE Refeicao SET Descricao = " + pizza.Descricao + " WHERE id = " + pizza.Id);
            conn = new ConnectionDB();
            conn.ExecQuery(sql);
        }

        public void Delete(Pizza pizza)
        {
            string sql = string.Format("DELETE FROM Refeicao WHERE Id = "+ pizza.Id);
            conn = new ConnectionDB();
            conn.ExecQuery(sql);
        }

        public List<Pizza> Select()
        {
            conn = new ConnectionDB();
            string sql = "SELECT Id, Descricao, Valor FROM Refeicao";
            var returnData = conn.ExecQueryReturn(sql);
            return TransformSQLToList(returnData);
        }

        public List<Pizza> SelectById(int id)
        {
            conn = new ConnectionDB();
            string sql = "SELECT Id, Descricao, Valor FROM Refeicao Where Id = "+id;
            var returnData = conn.ExecQueryReturn(sql);
            return TransformSQLToList(returnData);
        }

        private List<Pizza> TransformSQLToList(SqlDataReader returnData)
        {
            var list = new List<Pizza>();
            while (returnData.Read())
            {
                Pizza item = new Pizza()
                {
                    Id = int.Parse(returnData["Id"].ToString()),
                    Descricao = returnData["Descricao"].ToString(),
                    Valor = double.Parse(returnData["Valor"].ToString())
                };

                list.Add(item);
            }

            return list;
        }

    }
}
