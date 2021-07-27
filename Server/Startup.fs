namespace Heroism.Server

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Fable.Remoting.Server
open Fable.Remoting.AspNetCore
open Server

type Startup() =
    
    let serverApi =
        Remoting.createApi()
        |> Remoting.fromValue server

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    member _.ConfigureServices(services: IServiceCollection) =
        ()


    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member _.Configure(app: IApplicationBuilder, env: IWebHostEnvironment) =
        if env.IsDevelopment() then
            app.UseDeveloperExceptionPage() |> ignore

        app.UseRemoting(serverApi) |> ignore
