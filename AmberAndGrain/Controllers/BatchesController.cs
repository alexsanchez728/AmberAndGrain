using AmberAndGrain.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AmberAndGrain.Controllers
{
    [RoutePrefix("api/batches")]
    public class BatchesController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage AddBatch(AddBatchDto addBatch)
        {
            var repository = new BatchRepository();
            var result = repository.Create(addBatch.RecipeId, addBatch.Cooker);

            return (result)
                ? Request.CreateResponse(HttpStatusCode.Created)
                : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not create recipe. Please try again.");
        }
    }
}
