using Dapper;
using System.Configuration;
using System.Data.SqlClient;

namespace AmberAndGrain.Services
{
    public class BatchRepository
    {
        public bool Create(int recipeId, string cooker)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["AmberAndGrain"].ConnectionString))
            {
                db.Open();
                var numberAffected = db.Execute(@"Insert into Batches (
                            RecipeId,
                            Cooker)
                            Values (
                            @RecipeId,
                            @Cooker)", new {recipeId, cooker});
                return numberAffected == 1;
            }
        }
    }
}