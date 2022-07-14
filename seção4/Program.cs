// a linha 2 e 3 é o host  que vai estar escutando o que o usuario quer  fazer 
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

// como retorna um json em  um end point en c   
//app.MapGet("/user", () => new { Name = "Ester Silva ", Age = 35 });

// alterar o header de reposta / insira no metodo o obj responsavel para retornar a resposta nete caso é o HTTP Response 
// Toda vez que eu vou passar por um metodo eu dou o Nome depois o tipo da variavel . depois eu posso chamar resp.headers que é uma opção para chamr todos os heads e depois adicionar 
/*app.MapGet("/AddHeader", (HttpResponse response) =>
{
  response.Headers.Add("teste", "Ester Silva");
  return new{Name = "Ester Silva", Age = 33};
});*/
// neste met   env  informe prenchidas 
/*app.MapPost("/saveproduct", (Product product ) => {
  return product.Code + " - " + product.Name ;
});*/

//vc pode acessar a seguinte Ponte e através de parametros via url 
//api.app.com/user?datart{date}&dateend=[date] /Fazendo uma consulta passandoas informação atravez da url
/*app.MapGet("/getprodut", ([FromQuery] string dateStart, [FromQuery]string  stringDateEnd) =>{
  return  dateStart + " - " + dateEnd;
});*/

//api.app.com/user/{code}// tambem posso passar atraves da rota 
/*app.MapGet("/getprodut/{code}", ([FromRout] string code) =>{
  return  code;
});
*/

/*app.MapGet("/getproductbyheader", (HttpRequest request) =>{
  return request.Headers["product-code"].ToString();
});*/
app.MapPost("/saveproduct", (Product product) => {
 ProductRepository.Add(product);
});

app.MapGet("/getproduct/{code}" , ([FromRoute] String code ) => {
 var product = ProductRepository.GetBy(code);
 return product;
});

app.Run();

// representando o banco de dados 
public class ProductRepository{
  public List<Product> Products  {get; set;}
  
  public void Add(Product product) {
    if  (Product == null)
      product = new List<Product> ();

    Products.Add(product);
  }
  public Product GetBy(string code ){
    return Product.First(p => p.Code == code);
  }
    

}
 
 // Antes de criar o meu novo end poit   criar class para representar o produto 
// lembre que  tenho  que lembrar o tipo de acesso  "Public " o tipo  e o nome 
 public class Product { // estrutura da class de propriedade Produto
  public string Code { get; set; }//com dois  atributos
  public string   Name  { get; set; } // tipo get= obter o codigo / set = alterar 
 }
