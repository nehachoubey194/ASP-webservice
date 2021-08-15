using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class CS : System.Web.UI.Page
{   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindGrid();
        }
    }

    private void BindGrid()
    {
        CRUD_Service.ServiceCS service = new CRUD_Service.ServiceCS();
        GridView1.DataSource = service.Get();
        GridView1.DataBind();
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        con.Open();

        SqlCommand cmd = new SqlCommand("insert into Customer values(@CustomerId, @Name, @Country)", con);
        cmd.Parameters.AddWithValue("CustomerId", TextBox1.Text);
        cmd.Parameters.AddWithValue("Name", TextBox2.Text);
        cmd.Parameters.AddWithValue("Country", TextBox3.Text);
        cmd.ExecuteNonQuery();

        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";

        this.BindGrid();
    }

    protected void Button2_Click2(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);
        if (TextBox4.Text != "")
        {
            con.Open();
            string delete = "delete from Customer where CustomerId=" + TextBox4.Text;
            SqlCommand cmd = new SqlCommand(delete, con);

            cmd.ExecuteNonQuery();
            TextBox4.Text = "";
            this.BindGrid();
        }
    }
}