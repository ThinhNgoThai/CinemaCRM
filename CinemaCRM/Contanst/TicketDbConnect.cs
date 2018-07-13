using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using CinemaCRM.Contanst;

/// <summary>
/// Summary description for DBConnect 
/// </summary>


public class TicketDBConnect
{
    static SqlConnection _connection;
    public static SqlConnection GetConnection()
    {
        _connection = new SqlConnection(Contanst.TicketConnection);
        if (_connection.State != ConnectionState.Open)
            _connection.Open();
        return _connection;
    }

    public DataTable myTable(string strQuerry)
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        try
        {
            SqlCommand cmd = new SqlCommand(strQuerry, TicketDBConnect.GetConnection());
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

        SqlCommand myCon = new SqlCommand(store, TicketDBConnect.GetConnection());
        myCon = addParamater(myCon, paramater);
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
    //LONGDT - 07/03/2017 - thay đổi code từ >>>
    public DataTable executeQuery(string store, params object[] paramater)
    {
        DataTable myTable = new DataTable();
        myTable.Columns.Add("Id", typeof(String));
        myTable.Columns.Add("Name", typeof(String));
        myTable.Columns.Add("Value", typeof(String));
        using (SqlConnection connection = new SqlConnection(Contanst.TicketConnection))
        {
            SqlCommand command = new SqlCommand(store, connection);
            command = addParamater(command, paramater);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    DataRow row = myTable.NewRow();
                    row["Id"] = reader["Id"];
                    row["Name"] = reader["Name"];
                    row["Value"] = reader["Value"];
                    myTable.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                reader.Close();
            }
        }
        return myTable;
    }
    // LONGDT - 07/03/2017 - kết thúc thay đổi <<<<

    //LONGDT - 28/02/2017 - thay đổi code từ >>>
    public static SqlCommand addParamater(SqlCommand command, params Object[] paramater)
    {
        for (int i = 0; i < paramater.Length; i += 2)
        {
            command.Parameters.Add(paramater[i].ToString(), paramater[i + 1]);
        }
        return command;
    }
    // LONGDT - 28/02/2017 - kết thúc thay đổi <<<<

    public static SqlCommand addParamater(string strQuery, params Object[] paramater)
    {
        SqlCommand command = new SqlCommand(strQuery, new SqlConnection(Contanst.TicketConnection));
        for (int i = 0; i < paramater.Length; i += 2)
        {
            command.Parameters.Add(paramater[i].ToString(), paramater[i + 1]);
        }
        return command;
    }

    public static bool RunQuery(string strQuery, params Object[] paramater)
    {

        using (SqlConnection connection = new SqlConnection(Contanst.TicketConnection))
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

        using (SqlConnection connection = new SqlConnection(Contanst.TicketConnection))
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
        SqlCommand command = new SqlCommand(store, TicketDBConnect.GetConnection());
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
        using (SqlConnection connection = new SqlConnection(Contanst.TicketConnection))
        {
            connection.Open();
            SqlCommand command = TicketDBConnect.CreateCommand(sql, parameters);
            command.Connection = connection;
            new SqlDataAdapter(command).Fill(table);

            return table;
        }
    }

    public static DataSet GetData(String sql, params Object[] parameters)
    {
        return TicketDBConnect.Fill(new DataSet(), sql, parameters);
    }

    public static int ExecuteNonQuery(String sql, params Object[] parameters)
    {

        using (SqlConnection connection = new SqlConnection(Contanst.TicketConnection))
        {
            connection.Open();
            SqlCommand command = TicketDBConnect.CreateCommand(sql, parameters);
            command.Connection = connection;
            int rows = command.ExecuteNonQuery();
            return rows;
        }

    }

    public static object ExecuteScalar(String sql, params Object[] parameters)
    {

        using (SqlConnection connection = new SqlConnection(Contanst.TicketConnection))
        {
            connection.Open();
            SqlCommand command = TicketDBConnect.CreateCommand(sql, parameters);
            command.Connection = connection;
            object value = command.ExecuteScalar();

            return value;
        }
    }

    private static SqlCommand CreateCommand(String sql, params Object[] parameters)
    {

        SqlCommand command = new SqlCommand(sql, TicketDBConnect.GetConnection());
        for (int i = 0; i < parameters.Length; i += 2)
        {
            command.Parameters.AddWithValue(parameters[i].ToString(), parameters[i + 1]);
        }

        return command;
    }

    public bool isExist(string store, params object[] paramater)
    {
        DataTable dt = myTable(store, paramater);

        //2016/06/14 ThienNQ Check table có row Count = 0
        if (dt.Rows.Count == 0) return false;

        if (dt.Rows[0].ItemArray[0].ToString() != "0")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Dispose()
    {
        if (_connection != null)
        {
            _connection.Dispose();
        }
    }
}