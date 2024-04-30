using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace CompanyWASMConsumer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddHttpClient<IServices<Employee>, EmployeeService>(
                httpclient => httpclient.BaseAddress =
                    new Uri(builder.Configuration.GetValue<string>("Ip"))
                );

            builder.Services.AddHttpClient<IServices<Department>, DepartmentService>(
                httpclient=>httpclient.BaseAddress=
                    new Uri(builder.Configuration.GetValue<string>("Ip")
                ));




            //builder.Services.AddScoped<IServices<Employee>, EmployeeService>();
            //builder.Services.AddScoped<IServices<Department>, DepartmentService>();

            //builder.Services
            //    .AddScoped(sp =>new HttpClient 
            //    { 
            //        //get ip from appsetting 
            //        BaseAddress = new Uri(builder.Configuration.GetValue<string>("Ip")) 
            //    });

            await builder.Build().RunAsync();
        }
    }
}
