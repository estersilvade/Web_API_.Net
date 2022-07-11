// a linha 2 e 3 é o host  que vai estar escutando o que o usuario quer  fazer 
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// como retorna um json em  um end point en c   
app.MapGet("/user", () => new { Name = "Ester Silva ", Age = 35 });

// alterar o header de reposta / insira no metodo o obj responsavel para retornar a resposta nete caso é o HTTP Response 
// Toda vez que eu vou passar por um metodo eu dou o Nome depois o tipo da variavel . depois eu posso chamar resp.headers que é uma opção para chamr todos os heads e depois adicionar 
app.MapGet("/AddHeader", (HttpResponse response) =>
{
  response.Headers.Add("teste", "Ester Silva");
  return new{Name = "Ester Silva", Age = 33};
});
// neste met   env  informe prenchidas 
app.MapPost("/saveproduct", (Product product ) => {
  return product.Code + " - " + product.Name ;
});


app.Run();
 
 // Antes de criar o meu novo end poit   criar class para representar o produto 
// lembre que  tenho  que lembrar o tipo de acesso  "Public " o tipo  e o nome 
 public class Product { // estrutura da class de propriedade Produto
  public string Code { get; set; }//com dois  atributos
  public string   Name  { get; set; } // tipo get= obter o codigo / set = alterar 
 }
