using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmpSol.Model;
using System.IO;
using System.Xml.Linq;

namespace EmpSol
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conGV = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["conGV"]));
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAllData();
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            EmpInfo emp = new EmpInfo();
            string imgPath = "";
           
            if (ImageUpload.HasFile)
            {
                string imgName = ImageUpload.FileName;
                string FileExtension = Path.GetExtension(ImageUpload.PostedFile.FileName);
                //sets the image path
                imgPath = "Images/" + imgName + DateTime.Now.ToString("yyyy-MM-dd HHmmtt") + FileExtension;
                //get the size in bytes that
                // int imgSize = ImageUpload.PostedFile.ContentLength;
                //validates the posted file before saving
                if (ImageUpload.PostedFile != null && ImageUpload.PostedFile.FileName != "")
                {
                    // 10240 KB means 10MB, You can change the value based on your requirement
                    //then save it to the Folder
                    ImageUpload.SaveAs(Server.MapPath(imgPath));

                }
            }
            else
            {
                imgPath = lblImage.Text;
            }
            if (BtnSubmit.Text == "Update")
            {
                emp.Id = Convert.ToInt32(hfId.Value);
                emp.EmpId=EmpIdBox.Text.Trim();
                emp.EmpName = EmpNameBox.Text.Trim();
                emp.EmpConNo = ContactBox.Text.Trim();
                emp.EmpEmailId = EmpEmailBox.Text.Trim();
                emp.EmpSal=SalBox.Text.Trim();
                emp.EmpImage = imgPath;
                int exec1 = EmpInfo.UpdateEmpT(conGV, emp);
                if (exec1 > 0)
                {
                    BindAllData();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Data updated Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('There is some problem now. Please trya after some time');", true);
                }
            }
            else
            {
                emp.EmpId = EmpIdBox.Text.Trim();
                emp.EmpName = EmpNameBox.Text.Trim();
                emp.EmpConNo = EmpEmailBox.Text.Trim();
                emp.EmpSal = SalBox.Text.Trim();
                emp.EmpEmailId = EmpEmailBox.Text.Trim();
                emp.EmpImage = imgPath;
                int exec = EmpInfo.InsertEmpT(conGV, emp);
                if (exec > 0)
                {
                    BindAllData();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Data inserted Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('There is some problem now. Please trya after some time');", true);
                }
            }
        }
        public void BindAllData()
        {
            DataTable dt = EmpInfo.GetAllEmpT(conGV);
            if (dt.Rows.Count > 0)
            {
                GdView.DataSource = dt;
                GdView.DataBind();
            }
            GenerateAutoId();
        }
        private void GenerateAutoId()
        {
            DataTable dt = EmpInfo.GetAllEmpT(conGV);
            string i = Convert.ToString(dt.Rows.Count + 1);
            EmpIdBox.Text = "NWI" + i.PadLeft(4, '0');
        }
        protected void GdView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GdView.PageIndex = e.NewPageIndex;
            BindAllData();
        }

        protected void GdView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = Convert.ToString(GdView.DataKeys[e.RowIndex].Values["Id"]);
            EmpInfo emp = new EmpInfo();
            emp.Id = Convert.ToInt32(id);
            int exec = EmpInfo.DeleteEmpT(conGV, emp);
            if (exec > 0)
            {
                BindAllData();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Data deleted Successfully');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('There is some problem now. Please try after some time');", true);
            }
        }


        protected void GdView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string id = Convert.ToString(GdView.DataKeys[e.NewSelectedIndex].Values["Id"]);

            DataTable dt = EmpInfo.GetSelectedEmpT(conGV, Convert.ToInt32(id));
            if (dt.Rows.Count > 0)
            {
                hfId.Value = Convert.ToString(dt.Rows[0]["Id"]);
                EmpNameBox.Text = Convert.ToString(dt.Rows[0]["EmpName"]);
                EmpEmailBox.Text = Convert.ToString(dt.Rows[0]["EmpEmailId"]);
                ContactBox.Text = Convert.ToString(dt.Rows[0]["EmpConNo"]);
                SalBox.Text = Convert.ToString(dt.Rows[0]["EmpSal"]);
                ImageID.ImageUrl = Convert.ToString(dt.Rows[0]["EmpImage"]);
                lblImage.Text = Convert.ToString(dt.Rows[0]["EmpImage"]);
                EmpIdBox.Text = Convert.ToString("Nwi" + hfId.Value);
                BtnSubmit.Text = "Update";

            }
        }   
       


        protected void GdView_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindAllData();
        }

    }
}