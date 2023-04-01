using VegDex.Application.Models;
using VegDex.Web.MVC.ViewModels.Base;

namespace VegDex.Web.MVC.ViewModels;

public class ShoppingViewModel : BaseViewModel
{
    public IEnumerable<VeganCompanyModel> VeganCompanies { get; set; }
    public IEnumerable<FarmersMarketModel> FarmersMarkets { get; set; }
}
