using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CariHesapTakip
{
    public class DbHelper
    {
        OleDbConnection conn;

        public void VTBaglantiAc() {
            conn = new OleDbConnection();
            conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=caridb.accdb";
            conn.Open();
        }

        public void VTBaglantiKapat()
        {
            conn.Close();
        }

        public void VeriGonder(string sql)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.ExecuteNonQuery();
        }

        public DataTable VeriGetir(string sql)
        {
            DataTable dt = new DataTable();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;

            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }
    }

}
