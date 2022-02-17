
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO_Select
{
    class Program
    {
        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {
                //Created the Connection
                con = new SqlConnection("data source =.;database=teacherdb; integrated security=SSPI");
                //Created or written sql statement or query
                //SqlCommand cm = new SqlCommand("create table teacher2(tech_id int not null,tech_name varchar(25),subject varchar(25))", con);

                //SqlCommand cm = new SqlCommand("insert into teacher2(tech_id,tech_name,subject)values(12,'Chandrasir','CSharp'),(14,'Vasusir','Cloud')", con);
                SqlCommand cm = new SqlCommand("select * from teacher2", con);
                con.Open();
                cm.ExecuteNonQuery();
                Console.WriteLine("\n \t Operation successfull in the SQL Server");

                SqlDataReader dr = cm.ExecuteReader();
                Console.WriteLine("tech_id \tName \tSubject");
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + "\t" + dr[1] + " " + dr[2]);
                    Console.WriteLine(dr["tech_id"] +"\t" + dr["tech_name"] + " " +dr["subject"]);
                    Console.WriteLine("tech_id" + dr[0].ToString());
                    Console.WriteLine("tech_name" + dr[1].ToString());
                    Console.WriteLine("subject" + dr[2].ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("\n \t Something went wrong while connecting or executing");
            }
            finally
            {
                con.Close();
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.CreateTable();
            Console.ReadLine();
        }
    }
}

