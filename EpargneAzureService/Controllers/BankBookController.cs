using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using EpargneAzureService.DataObjects;
using EpargneAzureService.Models;

namespace EpargneAzureService.Controllers
{
	public class BankBookController : TableController<BankBook>
	{
		protected override void Initialize(HttpControllerContext controllerContext)
		{
			base.Initialize(controllerContext);
			MobileServiceContext context = new MobileServiceContext();
			DomainManager = new EntityDomainManager<BankBook>(context, Request, Services);
		}

		// GET tables/BankBook
		public IQueryable<BankBook> GetAllBankBook()
		{
			return Query();
		}

		// GET tables/BankBook/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public SingleResult<BankBook> GetBankBook(string id)
		{
			return Lookup(id);
		}

		// PATCH tables/BankBook/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public Task<BankBook> PatchBankBook(string id, Delta<BankBook> patch)
		{
			return UpdateAsync(id, patch);
		}

		// POST tables/BankBook
		public async Task<IHttpActionResult> PostBankBook(BankBook item)
		{
			BankBook current = await InsertAsync(item);
			return CreatedAtRoute("Tables", new { id = current.Id }, current);
		}

		// DELETE tables/BankBook/48D68C86-6EA6-4C25-AA33-223FC9A27959
		public Task DeleteBankBook(string id)
		{
			return DeleteAsync(id);
		}

	}
}