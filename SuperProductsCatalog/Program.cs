using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using SuperProductsCatalog.Model.Data;

namespace SuperProductsCatalog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // DI with IoC
            builder.Services.AddDbContext<ProductsDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //builder.Services.AddOData();


            // with odata configuration

            builder.Services.AddControllers().AddXmlSerializerFormatters()
                .AddOData(options =>
                {
                    options.Select().SetMaxTop(100).SkipToken().OrderBy().Count().Filter().Expand();
                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // odata



            var app = builder.Build();





            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            // odata
            //app.UseEndpoints(ep =>
            //{
            //    ep.EnableDependencyInjection();
            //    ep.Select();
            //    ep.Filter();
            //    ep.OrderBy();
            //    ep.MaxTop(100);
            //    ep.SkipToken();
            //    ep.MapControllers();
            //});

            app.MapControllers();

            app.Run();
        }
    }
}