using AutoMapper;
using EmployeeDetailsAPI.Models;
using EmployeeDetailsData.EmployeeDetails;


namespace EmployeeDetailsAPI.EmployeeLoader
{
    public class LoadEmployee
    {
        private readonly MapperConfiguration employeeDTOToEFConfig;
        private readonly MapperConfiguration employeeEFToDTOConfig;

        public LoadEmployee()
        {
            employeeEFToDTOConfig = new MapperConfiguration(config => config.CreateMap<EmployeeDetailsEF, EmployeeDTO>());
            employeeDTOToEFConfig = new MapperConfiguration(config => config.CreateMap<EmployeeDTO, EmployeeDetailsEF>());
        }

        public IMapper CreateEFToDTOMapper()
        {
            return employeeEFToDTOConfig.CreateMapper();
        }

        public IMapper CreateDTOToEFMapper()
        {
            return employeeDTOToEFConfig.CreateMapper();
        }
    }
}