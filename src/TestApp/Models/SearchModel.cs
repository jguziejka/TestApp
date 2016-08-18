
namespace TestApp.Models
{
    public class SearchModel
    {
        private SearchViewModel _vm;
        public SearchModel(SearchViewModel vm)
        {
            _vm = vm;
        }
        public string Address => _vm.Address;
        public string CityStateZip => $"{_vm.City} {_vm.State} {_vm.Zip}".Trim();
        public bool RentzEstimate => _vm.RentzEstimate;
    }
}
