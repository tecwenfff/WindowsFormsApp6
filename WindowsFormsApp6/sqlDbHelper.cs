using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    class sqlDbHelper
    {
        private string connectString;
        public string ConnectString
        {
            set { connectString = value; }
            get { return connectString; }
        }

        public sqlDbHelper()
        {
            this.connectString = ConfigurationManager.ConnectionStrings["DataConn"].ConnectionString;
        }
        public sqlDbHelper(string constr)
        {
            this.connectString = constr;
        }




        public int ExecuteNonquery(string strSql, CommandType commandType,params SqlParameter[] parameters)
        {
            int count = 0;
            using (SqlConnection con = new SqlConnection(ConnectString))
            {
                using (SqlCommand cmd = new SqlCommand(strSql, con))
                {
                    cmd.CommandType = commandType;
                    cmd.CommandText = strSql;
                    foreach (SqlParameter pa in parameters)
                    {
                        cmd.Parameters.Add(pa);
                    }
                    con.Open();
                    count = cmd.ExecuteNonQuery();
                }
            }
            return count;
        }

        public object ExecuteScalar(string strSql, CommandType commandType, SqlParameter[] parameters)
        {
            object obj;
            using (SqlConnection con = new SqlConnection(ConnectString))
            {
                using (SqlCommand cmd = new SqlCommand(strSql, con))
                {
                    cmd.CommandType = commandType;
                    //cmd.CommandText = strSql;
                    if (parameters != null)
                    {
                        foreach (SqlParameter pa in parameters)
                        {
                            cmd.Parameters.Add(pa);
                        }
                    }
                    con.Open();
                    obj = cmd.ExecuteScalar();
                }
            }
            return obj;
        }

        public object ExecuteScalar(string strSql, CommandType commandType)
        {
            return ExecuteScalar(strSql, commandType, null);
        }

        public object ExecuteScalar(string strSql)
        {
            return ExecuteScalar(strSql, CommandType.Text, null);
        }

        public SqlDataReader ExecuteReader(string strSql, CommandType commandType, SqlParameter[] parameters)
        {
            SqlDataReader reader;
            SqlConnection con = new SqlConnection(ConnectString);
            SqlCommand cmd = new SqlCommand(strSql, con);
            cmd.CommandType = commandType;
            if (parameters != null)
            {
                foreach (SqlParameter pa in parameters)
                {
                    cmd.Parameters.Add(pa);
                }
            }
            con.Open();
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        public SqlDataReader ExecuteReader(string strSql, CommandType commandType)
        {
            return ExecuteReader(strSql, commandType, null);
        }
        public SqlDataReader ExecuteReader(string strSql)
        {
            return ExecuteReader(strSql, CommandType.Text);
        }
        public static SqlDataAdapter ExecuteAdapter(string strSql, CommandType commandType, SqlParameter[] parameters, SqlConnection con)
        {
            //SqlDataAdapter adapter;
            //con = new SqlConnection(ConnectString);
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand cmd = new SqlCommand(strSql, con);
                cmd.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (SqlParameter pa in parameters)
                    {
                        cmd.Parameters.Add(pa);
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                return adapter;
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
            
            //con.Open();
            //reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //return reader;
        }
        public DataTable ExecuteDataTable(string strSql, CommandType commandType, SqlParameter[] parameters)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = new SqlConnection(ConnectString))
            {
                using (SqlCommand cmd = new SqlCommand(strSql, con))
                {

                    cmd.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (SqlParameter pa in parameters)
                        {
                            cmd.Parameters.Add(pa);
                        }
                    }
                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table);
                    }
                }

            }
            return table;
        }

    }
}