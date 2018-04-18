using AmberAndGrain.Models;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace AmberAndGrain.Services
{
    public class RecipeRepository
    {
        public bool Create(RecipeDto recipe)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["AmberAndGrain"].ConnectionString))
            {
                db.Open();
                var numberCreated = db.Execute(@"INSERT INTO [dbo].[Recipes]
                           ([Name]
                           ,[PercentWheat]
                           ,[PercentCorn]
                           ,[BarrelAge]
                           ,[BarrelMaterial]
                           ,[Creator])
                     VALUES
                           (@Name
                           ,@PercentWheat
                           ,@PercentCorn
                           ,@BarrelAge
                           ,@BarrelMaterial
                           ,@Creator)", recipe);
                return numberCreated == 1;
            }
        }

        public List<RecipeDto> GetAll()
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["AmberAndGrain"].ConnectionString))
            {
                db.Open();

                var result = db.Query<RecipeDto>("Select * from recipes");

                return result.ToList();
            }
        }

        public RecipeDto Get(int id)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["AmberAndGrain"].ConnectionString))
            {
                db.Open();

                var result = db.QueryFirst<RecipeDto>(@"Select * from recipes where id = @id", new { id });

                return result;
            }
        }
        public void Update(int id, RecipeDto recipe)
        {
            using (var db = new SqlConnection(ConfigurationManager.ConnectionStrings["AmberAndGrain"].ConnectionString))
            {
                db.Open();

                db.Execute(@"Update Recipes
                            set Name = @Name
                           ,PercentWheat = @PercentWheat
                           ,PercentCorn = @PercentCorn
                           ,BarrelAge = @BarrelAge
                           ,BarrelMaterial = @BarrelMaterial
                           ,Creator = @Creator)
                            where id = @id", new
                {
                    recipe.Name,
                    recipe.PercentWheat,
                    recipe.PercentCorn,
                    recipe.BarrelAge,
                    recipe.BarrelMaterial,
                    recipe.Creator,
                    id
                });
            }
        }
    }
}