namespace CarSalesApp.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IndexCarViewModel> Cars { get; set; }
    }
}
