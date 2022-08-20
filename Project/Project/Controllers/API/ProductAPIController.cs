using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Controllers.API
{
    [Route("api/ProductAPI/{action}")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly ProductContext _ProductDb;

        public ProductAPIController(ProductContext ProductDb)
        {
            _ProductDb = ProductDb;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProduct()
        {
            if (_ProductDb.Products == null)
            {
                return NotFound();
            }
            return _ProductDb.Products.ToList();
        }
        //新增
        [HttpPost]
        public void Addonce([FromBody]Product ProductInfo)
        {
            _ProductDb.Products.Add(ProductInfo);
            try
            {
                _ProductDb.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                HttpResponse response = this.Response;
                response.StatusCode = 400;
            }
        }

        //修改
        [HttpPut]
        public void EditInfo([FromBody]Product ProductInfo)
        {
            _ProductDb.Products.Add(ProductInfo);
            _ProductDb.Entry<Product>(ProductInfo).State = EntityState.Modified;
            try
            {
                _ProductDb.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                HttpResponse response = this.Response;
                response.StatusCode = 400;
            }
        }
        //刪除
        [HttpDelete]
        [Route("/delete/data")]
        public void DeleteProduct([FromQuery(Name="id")]int id)
        {
           var Info= _ProductDb.Products.Where(p => p.ProductId == id).FirstOrDefault<Product>();
            _ProductDb.Entry<Product>(Info).State = EntityState.Deleted;
            try
            {
                _ProductDb.SaveChanges();
            }
            catch
            {
                HttpResponse response = this.Response;
                response.StatusCode = 400;
            }
        }
    }
}
