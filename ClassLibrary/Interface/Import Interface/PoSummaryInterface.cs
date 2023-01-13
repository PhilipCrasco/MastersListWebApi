using ClassLibrary.model.PoSummary;

namespace ClassLibrary.Interface.Import_Interface
{
    public interface PoSummaryInterface
    {

        Task<bool> AddPoSummaryRequest(PoSummary posummary);

        Task<bool> CheckItemCode(string itemcode);
        Task<bool> Checkvendor(string vendor);
        Task<bool> CheckUom(string uom);
        Task<bool> ValidatePoandItemcodeManual(int ponumber, string itemcode);


        



    }
}
