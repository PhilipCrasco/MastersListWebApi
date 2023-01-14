using ClassLibrary.Data_Acess_Layer.Dto.Users_Model_Dto;
using ClassLibrary.Data_Acess_Layer.model.UsersModel;
using ClassLibrary.Interface.User_Model_Interface;
using ClassLibrary.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data_Acess_Layer.Repository.UserModelRepository
{
    public class DepartmentRepository : IDepartment
    {
        private readonly StoreContext _context;

        public DepartmentRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<DtoDepartment>> GetAllActiveDepartment()
        {
            var department = _context.Departments.Where(x => x.IsActive == true)
                                                 .Select(x => new DtoDepartment
                                                 { 
                                                     Id= x.Id,
                                                    DepartmentCode= x.DepartmentCode,
                                                    DepartmentName= x.DepartmentName,
                                                    DateAdded = x.DateAdded.ToString("MM/dd/yyyy"),
                                                    AddedBy= x.AddedBy,
                                                    IsActive= x.IsActive


                                                 });

            return await department.ToListAsync();

        }

        public async Task<IReadOnlyList<DtoDepartment>> GetAllInActiveDepartment()
        {
            var department = _context.Departments.Where(x => x.IsActive == false)
                                                  .Select(x => new DtoDepartment
                                                  {
                                                      Id = x.Id,
                                                      DepartmentCode = x.DepartmentCode,
                                                      DepartmentName = x.DepartmentName,
                                                      DateAdded = x.DateAdded.ToString("MM/dd/yyyy"),
                                                      AddedBy = x.AddedBy,
                                                      IsActive = x.IsActive


                                                  });

            return await department.ToListAsync();
        }

        public async Task<bool> AddnewDapartment(Department department)
        {
           await _context.Departments.AddAsync(department);
            return true;
        }

        public async  Task<bool> UpdateDepartment(Department department)
        {
            var update = await _context.Departments.Where(x => x.Id == department.Id)
                                                   .FirstOrDefaultAsync();

            update.DepartmentName = department.DepartmentName;
            update.DepartmentCode = department.DepartmentCode;
            update.AddedBy= department.AddedBy;
            update.DateAdded = department.DateAdded;
            
            return true;
        }

        public async Task<bool> UpdateActiveDepartment(Department department)
        {

            var update = await _context.Departments.Where(x => x.Id == department.Id)
                                                  .FirstOrDefaultAsync();

            update.IsActive = department.IsActive = true;

            return true;
        }

        public async Task<bool> UpdateInActiveDepartment(Department department)
        {

            var update = await _context.Departments.Where(x => x.Id == department.Id)
                                                  .FirstOrDefaultAsync();

            update.IsActive = department.IsActive = false;

            return true;

        }

            //Validate

            public async Task<bool> ExistingDeptId(int deptId)
        {
            var departmentid = await _context.Departments.FindAsync(deptId);

            if(departmentid == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> ValidateDepartmentCode(string code)
        {
            return await _context.Departments.AnyAsync(x => x.DepartmentCode == code);
        }

       
    }
}
