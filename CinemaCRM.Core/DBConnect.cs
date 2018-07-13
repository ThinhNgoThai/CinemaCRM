using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using CinemaCRM.Core;
/// <summary>
/// Summary description for DBConnect 
/// </summary>


public class DBConnect 
{

    //static string Connect = Common.Connection;//WebConfigurationManager.ConnectionStrings["ConnectVietnamtravel24"].ConnectionString;
   // static string Connect = @"Data Source=118.70.170.147;Max Pool Size=8192;Initial Catalog=OnlineCinemaTicketDB;User ID=demo31;pwd=demo31@123456789";
    static string Connect = @"Data Source=192.168.100.119;Max Pool Size=8192;Initial Catalog=CinemaTicket2014Test;User ID=sa;pwd=sa123";

    //static string Connect = @"Data Source=192.168.3.1;Max Pool Size=8192;Initial Catalog=CinemaTicket2014;User ID=sa;pwd=Sa@123456";
    //static string Connect = @"Data Source=PC2014021510KZA\MSSQLSERVER12;Max Pool Size=8192;Initial Catalog=CinemaTicket2014;User ID=sa;pwd=sysdba";
   
    static SqlConnection _connection;
    public static SqlConnection GetConnection()
    {
        _connection = new SqlConnection(Connect);
        _connection.Open();
        return _connection;
    }
    
    public DataTable myTable(string strQuerry)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        try
        {
            SqlCommand cmd = new SqlCommand(strQuerry, DBConnect .GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);// Bắt lỗi
        }

        return dt;
    }

    public DataTable myTable(string store, params object[] paramater)
    {

        SqlCommand myCon = new SqlCommand(store, DBConnect .GetConnection());
        myCon = addParamater(store, paramater);
        myCon.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter myAdapter = new SqlDataAdapter(myCon);
        myAdapter.SelectCommand = myCon;
        myAdapter.SelectCommand.CommandTimeout = 120;
        DataTable myTable = new DataTable();
        try
        {
            myAdapter.Fill(myTable);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);// Bắt lỗi
        }

        return myTable;
    }

    public static SqlCommand addParamater(string strQuery, params Object[] paramater)
    { 
            SqlCommand command = new SqlCommand(strQuery,new SqlConnection(Connect));
            for (int i = 0; i < paramater.Length; i += 2)
            {
                command.Parameters.Add(paramater[i].ToString(), paramater[i + 1]);
            }
            return command; 
    }     

    public static bool RunQuery(string strQuery, params Object[] paramater)
    {

        using (SqlConnection connection = new SqlConnection(Connect))
        {
            connection.Open();

            SqlCommand command = addParamater(strQuery, paramater);
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction transaction;
            // Start a local transaction.
            transaction = connection.BeginTransaction("SampleTransaction");

            // Must assign both transaction object and connection 
            // to Command object for a pending local transaction
            command.Connection = connection;
            command.Transaction = transaction;
            try
            {
                command.ExecuteNonQuery();
                transaction.Commit();
                return true;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                throw ex;
                return false;
            }
        }     
    
    }

    public static int RunQueryReturnID(string strQuery, params Object[] paramater)
    {

        using (SqlConnection connection = new SqlConnection(Connect))
        {
            connection.Open();

            SqlCommand command = addParamater(strQuery, paramater);
            command.CommandType = CommandType.StoredProcedure;
            SqlTransaction transaction;

            // Start a local transaction.
            transaction = connection.BeginTransaction("SampleTransaction");

            // Must assign both transaction object and connection 
            // to Command object for a pending local transaction
            command.Connection = connection;
            command.Transaction = transaction;
            try
            {
                int newID = Convert.ToInt32(command.ExecuteScalar().ToString());
                transaction.Commit();
                return newID;
            }
            catch (SqlException ex)
            {
                transaction.Rollback();
                return -1;
            }

        }  
    }
    
    // xử lý dữ liệu trả về datasset
    public DataSet myDataset(string store, params object[] paramater)
    {
        SqlCommand command = new SqlCommand(store, DBConnect.GetConnection());
        command = addParamater(store, paramater);
        command.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter myAdapter = new SqlDataAdapter(command);
        myAdapter.SelectCommand = command;
        DataSet myDataset = new DataSet();
        try
        {
            myAdapter.Fill(myDataset);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);// Bắt lỗi
        }

        return myDataset;
    }

    public static DataSet Fill(DataSet table, String sql, params Object[] parameters)
    {
        using (SqlConnection connection = new SqlConnection(Connect))
        {
            connection.Open();
            SqlCommand command = DBConnect.CreateCommand(sql, parameters);
            command.Connection = connection;
            new SqlDataAdapter(command).Fill(table);
     
            return table;
        }
    }

    public static DataSet GetData(String sql, params Object[] parameters)
    {
        return DBConnect .Fill(new DataSet(), sql, parameters);
    }

    public static int ExecuteNonQuery(String sql, params Object[] parameters)
    {

        using (SqlConnection connection = new SqlConnection(Connect))
        {
            connection.Open();
            SqlCommand command = DBConnect.CreateCommand(sql, parameters);
            command.Connection = connection;
            int rows = command.ExecuteNonQuery();           
            return rows;
        }

    }

    public static object ExecuteScalar(String sql, params Object[] parameters)
    {

        using (SqlConnection connection = new SqlConnection(Connect))
        {
            connection.Open();
            SqlCommand command = DBConnect.CreateCommand(sql, parameters);
            command.Connection = connection;
            object value = command.ExecuteScalar();         

            return value;
        }
    }


    private static SqlCommand CreateCommand(String sql, params Object[] parameters)
    {

        SqlCommand command = new SqlCommand(sql, DBConnect .GetConnection());
        for (int i = 0; i < parameters.Length; i += 2)
        {
            command.Parameters.AddWithValue(parameters[i].ToString(), parameters[i + 1]);
        }

        return command;
    }
}


