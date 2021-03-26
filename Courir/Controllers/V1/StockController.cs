namespace Courir.WebApi.Controllers.V1
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Courir.BusinessObject;
    using Courir.IBusiness;
    using Courir.WebApi.Route;

    using Microsoft.AspNetCore.Mvc;

    [Route(StockRoute.RoutePrefix)]
    public class StockController : Controller
    {
        private readonly IStockBusiness stockBusiness;

        public StockController(IStockBusiness stockBusiness)
        {
            this.stockBusiness = stockBusiness;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            KeyValuePair<bool, Stock> result = await this.stockBusiness.Delete(id);

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
            Stock stock = await this.stockBusiness.Get(id);

            if (stock != null)
            {
                return this.Ok(stock);
            }

            return this.NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return this.Ok(await this.stockBusiness.List());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Stock stock)
        {
            KeyValuePair<bool, Stock> result = await stockBusiness.Create(stock);

            if (result.Key)
            {
                return this.Ok(result.Value);
            }

            return this.BadRequest(result.Value.ValidationService.ModelState);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Stock stock)
        {
            KeyValuePair<bool, Stock> result = await this.stockBusiness.Update(id, stock);

            if (result.Key)
            {
                return this.Ok(result.Value);
            }

            return this.BadRequest(result.Value.ValidationService.ModelState);
        }
    }
}