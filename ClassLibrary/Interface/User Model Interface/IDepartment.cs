using ClassLibrary.Data_Acess_Layer.Dto.Users_Model_Dto;
using ClassLibrary.Data_Acess_Layer.model.UsersModel;

namespace ClassLibrary.Interface.User_Model_Interface
{
    public interface IDepartment
    {
        Task<IReadOnlyList<DtoDepartment>> GetAllActiveDepartment();
        Task<IReadOnlyList<DtoDepartment>> GetAllInActiveDepartment();

        Task<bool> AddnewDapartment(Department department);

        Task<bool> UpdateDepartment(Department department);

        Task<bool> UpdateActiveDepartment(Department department);

        Task<bool> UpdateInActiveDepartment(Department department);

        //Validate

        Task<bool> ValidateDepartmentCode (string code);
        Task <bool> ExistingDeptId (int deptId);

    }
}
