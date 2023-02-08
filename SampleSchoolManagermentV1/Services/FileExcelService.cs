using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Repository.UnitOfWork;
using SampleSchoolManagermentV1.Services.Interfaces;

namespace SampleSchoolManagermentV1.Services
{
    public class FileExcelService : IFileExcelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<FileExcelService> _logger;
        public FileExcelService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<FileExcelService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<InforTimeTable>> CreateTimeTable(int id)
        {
            List<string> include = new List<string> { "InformationSubject", "InformationClass" };
            var timeTableList = await _unitOfWork.TimeTableRepository.GetAllAsync(include);
            if (timeTableList.Any())
            {
                var result = timeTableList.Where(x => x.Classid == id)
               .ToList();
                if (result != null)
                {
                    _logger.LogInformation($"Export Data TimeTable of Class: to Excel");
                    return result;
                }
                _logger.LogError($"Cannot export Data TimeTable of Class: to Excel");
                return null;
            }
            _logger.LogError("Cannot export data");
            return null;
        }
    }
}
