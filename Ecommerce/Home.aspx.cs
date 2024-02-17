using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Ecommerce
{
    public partial class Home : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DBConn.conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products",DBConn.conn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                string content = "";

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        content += $@"<div class=""col"">
                                       <div class=""card h-100 d-flex flex-column justify-content-between"">
                                                                 <div class=""p-2"">
                                              <img src=""{dataReader["Image"]}"" class=""card-img-top rounded"" alt=""{dataReader["Nome"]}"">
                                          
                                                                </div>
                                             <div>
                                                 <div class=""card-body "">
                                              <h6 class=""card-title fw-bolder"">{dataReader["Nome"]}</h6>
                                              <p class=""card-text  text-secondary"" style=""font-size:0.8em;"">{dataReader["Descrizione"]}</p>   
                                           </div>
                                             <div class="" d-flex justify-content-around align-items-baseline p-3"">
                                                
                                               <p class=""card-text me-2"">€{dataReader["Prezzo"]}</p>
                                               <a href=""Dettaglio.aspx?product={dataReader["ID"]}"" style=""font-size:0.7em;"" class=""btn btn-dark rounded-pill"">Details</a>
                                            </div>
                                               </div>
                                          
                                          
                                              
                                           </div>
                                      </div> ";

                    }
                }
                contentHtml.InnerHtml = content;
            }
            catch(Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                if(DBConn.conn.State == ConnectionState.Open)
                {
                    DBConn.conn.Close();
                }
            }


        }
    }
}