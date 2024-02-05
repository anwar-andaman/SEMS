using Microsoft.Data.SqlClient;
using System.Data;

namespace SEMS
{
    public class DataManager
    {
        public String constr;
        public DataManager()
        {
            //this.constr = config.GetConnectionString("MyDatabaseConnection");

            this.constr = "Server=.;Database=STATE_ELECTION;User=sa;Password=sa@Admin;TrustServerCertificate=True;";
        }

        // ("DefaultConnection");// ConfigurationManager.ConnectionStrings("DataConnection").ConnectionString
        // SqlConnection con = new SqlConnection();
        public void makeconnection(ref SqlConnection con)
        {
            con.ConnectionString = constr;
            if (con.State != ConnectionState.Open)
                con.Open();
        }


        public int create_scalar(String sqlqry, ref SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(sqlqry, con);
            int i = (int)cmd.ExecuteScalar();
            con.Close();
            return i;
        }

        public int create_scalar_with_transaction(String sqlqry, ref SqlConnection con, SqlTransaction t)
        {
            int i;
            SqlCommand cmd = new SqlCommand(sqlqry, con);
            cmd.Transaction = t;
            i = (int)cmd.ExecuteScalar();

            return i;
        }

        public DataSet create_dataset(String sqlqry, ref SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand(sqlqry, con);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;
            ad.Fill(ds);
            con.Close();
            return ds;
        }


        public int runquery(String sqlqry, ref SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand(sqlqry, con);

            int n = (int)cmd.ExecuteNonQuery();
            con.Close();
            return (n);
        }
        public SqlDataReader create_reader(String sqlqry, ref SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand(sqlqry, con);

            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            con.Close();
            return dr;
        }

        public int do_transaction(String sqlqry, ref SqlConnection con, SqlTransaction t)
        {

            SqlCommand cmd = new SqlCommand(sqlqry, con, t);
            int n = (int)cmd.ExecuteNonQuery();
            //con.Close();
            return n;
        }




        public DataSet create_dataset_with_transaction(String sqlqry, ref SqlConnection con, SqlTransaction t)
        {
            SqlCommand cmd = new SqlCommand(sqlqry, con, t);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;
            ad.Fill(ds);
            return ds;

        }
    }
}
