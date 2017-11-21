using System;
using System.Collections.Generic;
using VehicleDetails.Dal.Interface;
using VehicleDetails.Dal.Models;
using System.Data.SqlClient;
using System.Data;

namespace VehicleDetails.Dal.Implementation
{
    public class VehicleDataAccess : IVehicleDataAccess
    {
        SqlConnection con = new SqlConnection("Data Source = .\\SQLEXPRESS;Initial Catalog = AutomobileDb;Integrated Security=SSPI");
        
        public int AddVehicle(VehicleModel vehicle)
        {
            string queryString = "Insert into dbo.AutomobileInfo (Make,Model,Year)" +
                "values (@Make,@Model,@Year) SELECT CAST(scope_identity() AS int) ";
            VehicleModel vmod = new VehicleModel();
            SqlCommand cmd = new SqlCommand(queryString, con);
            SqlParameter param = new SqlParameter();
            cmd.Parameters.Add("@Make",SqlDbType.VarChar).Value = vehicle.Make;
            cmd.Parameters.Add("@Model", SqlDbType.VarChar).Value = vehicle.Model;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = vehicle.Year;

            try
            {
                con.Open();
                int identity = Convert.ToInt32(cmd.ExecuteScalar());
                return identity;

            }
            catch(SqlException)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }

        }

        public void DeleteVehicle(int Id)
        {
            string queryString = "Delete from dbo.AutomobileInfo where Id= @Id";
            VehicleModel vmod = new VehicleModel();
            SqlCommand cmd = new SqlCommand(queryString, con);
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            cmd.Parameters.Add(param);

            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if(! (result > 0))
                {
                    throw new Exception("The references Id was not found");
                }
            }
            catch (SqlException)
            {
              
            }
            finally
            {
                con.Close();
            }
        }

        public VehicleModel GetVehicleById(int Id)
        {
            string queryString = "Select * from dbo.AutomobileInfo where Id= @Id";
            VehicleModel vmod = new VehicleModel();
            SqlCommand cmd = new SqlCommand(queryString, con);
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            cmd.Parameters.Add(param);


            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        vmod.Id = Convert.ToInt32(reader["Id"]);
                        vmod.Make = reader["Make"].ToString();
                        vmod.Model = reader["Model"].ToString();
                        vmod.Year = Convert.ToInt32(reader["Year"]);
                    }
                }
                else
                {
                    throw new Exception("The Referrenced id was not found");
                }
                reader.Close();
            }
            catch(SqlException)
            {
                
            }
            finally
            {

                con.Close();
            }
            return vmod;
        }

        public List<VehicleModel> GetVehicles()
        {
            string queryString = "Select * from dbo.AutomobileInfo";
            List<VehicleModel> vlist = new List<VehicleModel>();
            SqlCommand cmd = new SqlCommand(queryString, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    vlist.Add(new VehicleModel()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Make = reader["Make"].ToString(),
                        Model = reader["Model"].ToString(),
                        Year = Convert.ToInt32(reader["Year"])
                    });
                }
                reader.Close();
            }
            catch(SqlException)
            {
                
            }
            finally
            {
                
                con.Close();
            }
            return vlist;
        }

        public void UpdateVehicle(VehicleModel vehicle)
        {
            string queryString = "Update dbo.AutomobileInfo Set Make=@Make,Model = @Model ,Year = @Year where Id = @Id";
            SqlCommand cmd = new SqlCommand(queryString, con);
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = vehicle.Id;
            cmd.Parameters.Add("@Make", SqlDbType.VarChar).Value = vehicle.Make;
            cmd.Parameters.Add("@Model", SqlDbType.VarChar).Value = vehicle.Model;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = vehicle.Year;

            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();

                if(!(result > 0))
                {
                    throw new Exception("The referenced Id does not exist");
                }
            }
            catch (SqlException)
            {
                
            }
            finally
            {
                con.Close();
            }
        }
    }
}
