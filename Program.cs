namespace projetoWebLhPetsV1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.UseStaticFiles();

        app.MapGet("/", () => "Projeto Web - LH Pets versão 1");

        app.MapGet("/index", (HttpContext contexto) => {
            contexto.Response.Redirect("index.html", false);
        });

        Banco dba = new Banco();
        app.MapGet("/listaClientesindex", (HttpContext contexto) => {
            contexto.Response.WriteAsync(dba.GetListaString());
        });

        app.Run();
    }
}
