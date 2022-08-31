using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EmpSol.Model
{
    public class EmpInfo
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpConNo { get; set; }
        public string EmpEmailId { get; set; }
        public string EmpSal { get; set; }
        public string EmpImage { get; set; }

        public static DataTable GetAllEmpT(SqlConnection conGV)
        {
            DataTable categories = new DataTable();
            try
            {
                string query = "Select *  from EmpInfoT where IdStatus ='Active' ";
                using (SqlCommand cmd = new SqlCommand(query, conGV))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(categories);
                }
            }
            catch (Exception ex)
            {
            }
            return categories;
        }

        public static DataTable GetSelectedEmpT(SqlConnection conGV, int id)
        {
            DataTable categories = new DataTable();
            try
            {
                string query = "Select *  from EmpInfoT Where Id=@Id AND IDStatus ='Active'" ;
                using (SqlCommand cmd = new SqlCommand(query, conGV))
                {
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = id;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(categories);
                }
            }
            catch (Exception ex)
            {
            }
            return categories;
        }
        public static int InsertEmpT(SqlConnection conGV, EmpInfo emp)
        {
            int result = 0;
            try
            {
                string query = "Insert Into EmpInfoT(EmpId,EmpName,EmpConNo,EmpEmailId,EmpSal,EmpImage) values(@EmpId, @EmpName,@EmpConNo,@EmpEmailId,@EmpSal,@EmpImage)";
                using (SqlCommand cmd = new SqlCommand(query, conGV))
                {
                    cmd.Parameters.AddWithValue("@EmpId", SqlDbType.NVarChar).Value = emp.EmpId;
                    cmd.Parameters.AddWithValue("@EmpName", SqlDbType.NVarChar).Value = emp.EmpName;
                    cmd.Parameters.AddWithValue("@EmpConNo", SqlDbType.NVarChar).Value = emp.EmpConNo;
                    cmd.Parameters.AddWithValue("@EmpEmailId", SqlDbType.NVarChar).Value = emp.EmpEmailId;
                    cmd.Parameters.AddWithValue("@EmpSal", SqlDbType.NVarChar).Value = emp.EmpSal;
                    cmd.Parameters.AddWithValue("@EmpImage", SqlDbType.NVarChar).Value = emp.EmpImage;
                    conGV.Open();
                    result = cmd.ExecuteNonQuery();
                    conGV.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public static int UpdateEmpT(SqlConnection conGV, EmpInfo emp)
        {
            int result = 0;
            try
            {
                string query = "Update EmpInfoT Set EmpId=@EmpId,EmpName=@EmpName,EmpConNo=@EmpConNo,EmpEmailId=@EmpEmailId,EmpSal=@EmpSal ,EmpImage=@EmpImage Where Id=@Id ";
                using (SqlCommand cmd = new SqlCommand(query, conGV))
                {
                    cmd.Parameters.AddWithValue("@EmpId", SqlDbType.NVarChar).Value = emp.EmpId;
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = emp.Id;
                    cmd.Parameters.AddWithValue("@EmpName", SqlDbType.NVarChar).Value = emp.EmpName;
                    cmd.Parameters.AddWithValue("@EmpConNo", SqlDbType.NVarChar).Value = emp.EmpConNo;
                    cmd.Parameters.AddWithValue("@EmpEmailId", SqlDbType.NVarChar).Value = emp.EmpEmailId;
                    cmd.Parameters.AddWithValue("@EmpSal",SqlDbType.NVarChar).Value = emp.EmpSal;
                    cmd.Parameters.AddWithValue("@EmpImage", SqlDbType.NVarChar).Value = emp.EmpImage;
                    conGV.Open();
                    result = cmd.ExecuteNonQuery();
                    conGV.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public static int DeleteEmpT(SqlConnection conGV, EmpInfo cat)
        {
            int result = 0;
            try
            {
                string query = "Update EmpInfoT set IdStatus='InActive'";
                using (SqlCommand cmd = new SqlCommand(query, conGV))
                {
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                    conGV.Open();
                    result = cmd.ExecuteNonQuery();
                    conGV.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }

}