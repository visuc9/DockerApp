using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DockerApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                 SqlConnection cnn;
                string connetionString = "Data Source=visqlserver.database.windows.net;Initial Catalog=vidatabase;User ID=vi;Password=abc123@@";
            cnn = new SqlConnection(connetionString);
                string sql = "Select * from testtable";
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cnn.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.Read())
                {
                    await context.Response.WriteAsync(myReader["Name"].ToString()+"Vishnu999");
                    //sqlUname = myReader["USERNAME"].ToString();
                    ////MessageBox.Show(uname);
                    //textBox1.Text = sqlUname;
                }
                cnn.Close();
            });
        }
    }
}
