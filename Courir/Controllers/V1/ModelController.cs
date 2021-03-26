namespace Courir.WebApi.Controllers.V1
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Courir.BusinessObject;
    using Courir.IBusiness;
    using Courir.WebApi.Route;

    using Microsoft.AspNetCore.Mvc;

    [Route(ModelRoute.RoutePrefix)]
    public class ModelController : Controller
    {
        private readonly IModelBusiness modelBusiness;

        public ModelController(IModelBusiness modelBusiness)
        {
            this.modelBusiness = modelBusiness;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            KeyValuePair<bool, Model> result = await this.modelBusiness.Delete(id);

            if (result.Key)
            {
                return this.Ok(result.Value);
            }

            return this.BadRequest(result.Value);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            Model model = await this.modelBusiness.Get(id);

            if (model != null)
            {
                return this.Ok(model);
            }

            return this.NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return this.Ok(await this.modelBusiness.List());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Model model)
        {
            KeyValuePair<bool, Model> result = await modelBusiness.Create(model);

            if (result.Key)
            {
                return this.Ok(result.Value);
            }

            return this.BadRequest(result.Value.ValidationService.ModelState);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Model model)
        {
            KeyValuePair<bool, Model> result = await this.modelBusiness.Update(id, model);

            if (result.Key)
            {
                return this.Ok(result.Value);
            }

            return this.BadRequest(result.Value.ValidationService.ModelState);
        }
    }
}