using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Ingredients
{
    public class IngredientCreatecshtmlModel : PageModel
    {
        private readonly IService<Ingredient, int> _service;

        public IngredientCreatecshtmlModel(IService<Ingredient, int> service)
        {
            _service = service;
        }

        public Ingredient Ingredient { get; set; }

        public User User { get; set; }

        public void OnGet()
        {
            GetUser();
        }
        public IActionResult OnPost()
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Id = Convert.ToInt32(Request.Form["id"]);
            ingredient.Name = Convert.ToString(Request.Form["name"]);
            _service.Create(ingredient);
            return Redirect("/Ingredients/IngredientRetrieveall");
        }

        private void GetUser()
        {
            string user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                User = JsonSerializer.Deserialize<User>(user);
            }
        }
    }
}
