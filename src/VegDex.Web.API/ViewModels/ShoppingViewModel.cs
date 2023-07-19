using VegDex.Application.Models;
using VegDex.Web.API.ViewModels.Base;

namespace VegDex.Web.API.ViewModels;

public class ShoppingViewModel : BaseViewModel
{
    public IEnumerable<FarmersMarketModel>? FarmersMarkets { get; set; }
    public IEnumerable<VeganCompanyModel>? VeganCompanies { get; set; }
}
