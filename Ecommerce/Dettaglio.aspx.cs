using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce
{
    public partial class Dettaglio : System.Web.UI.Page
    {
     

        private string ProductID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["product"] == null)
            {
                Response.Redirect("Home.aspx");
            }

            ProductID = Request.QueryString["product"].ToString();

            try
            {
                DBConn.conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Products WHERE ID={ProductID}", DBConn.conn);
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    ttlProduct.InnerText = dataReader["Nome"].ToString();
                    img.Src = dataReader["Image"].ToString();
                    txtDescription.InnerText = dataReader["Descrizione"].ToString();
                    txtPrice.InnerText = $"{ dataReader["Prezzo"]}€";
                    dataReader.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                if (DBConn.conn.State == ConnectionState.Open)
                {
                    DBConn.conn.Close();
                }
            }


        }

        protected void btnAddCart_Click(object sender, EventArgs e)
        {
            int prodID = int.Parse(ProductID);
            List<int> products;
            if (Session["ProductID"] == null)
            {
                products = new List<int>();
            }
            else
            {
                products = (List<int>)Session["ProductID"];
            }

            products.Add(prodID);
            Session["ProductID"] = products;
            ScriptManager.RegisterStartupScript(this, GetType(), "addToCartAlert", "alert('Articolo aggiunto al carrello con successo!');", true);
            
        }
    }
}