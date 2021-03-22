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
    public class RefeicaoDB
    {
        private ConnectionDB conn;

        public void Insert(Refeicao refeicao)
        {
            string sql = string.Format("INSERT INTO Refeicao (Descricao) VALUES('{0}')", refeicao.Descricao);
            conn = new ConnectionDB();
            conn.ExecQuery(sql);

        }

        public List<Refeicao> Select()
        {
            conn = new ConnectionDB();
            string sql = "SELECT Id, Descricao, Valor FROM Refeicao";
            var returnData = conn.ExecQueryReturn(sql);
            return TransformSQLToList(returnData);




        }

        private List<Refeicao> TransformSQLToList(SqlDataReader returnData)
        {
            var list = new List<Refeicao>();
            while (returnData.Read())
            {
                Refeicao item = new Refeicao()
                {
                    Id = int.Parse(returnData["Id"].ToString()),
                    Descricao = returnData["Descricao"].ToString(),
                   // Valor = double.Parse(returnData["Valor"].ToString())
                };

                list.Add(item);
            }

            return list;
        }

    }
}
