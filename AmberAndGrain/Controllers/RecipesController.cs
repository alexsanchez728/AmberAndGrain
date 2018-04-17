using AmberAndGrain.Models;
using AmberAndGrain.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AmberAndGrain.Controllers
{
    [RoutePrefix("api/recipes")]
    public class RecipesController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage AddRecipe(RecipeDto recipe)
        {
            var recipeRepository = new RecipeRepository();
            var result = recipeRepository.Create(recipe);

            
           return ((result) 
                ? Request.CreateResponse(HttpStatusCode.Created) 
                : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not create recipe. Please try again."));
        }

        [Route(""), HttpGet]
        public HttpResponseMessage GetAllRecipes()
        {
            var repo = new RecipeRepository();
            List<RecipeDto> recipes = repo.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, recipes);

        }
    }
}
