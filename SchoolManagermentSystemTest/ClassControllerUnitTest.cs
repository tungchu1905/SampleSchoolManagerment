
using Microsoft.AspNetCore.Mvc;
using SampleSchoolManagermentV1.Services.Interfaces;
using SampleSchoolManagermentV1.Entities;
using System.Transactions;
using SampleSchoolManagermentV1.Validation;

namespace SchoolManagermentSystemTest
{
    public class ClassControllerUnitTest
    {
        private readonly IClassService _classService;
        public ClassControllerUnitTest(IClassService classService)
        {
                _classService= classService;
        }
        [Fact]
        public async Task TestGetStudentClass()
        {
            // Arrange
            var id = 1;

            // Act
            var response = await _classService.GetDetailClass(id) as ObjectResult;
            var value = response.Value as SingleResponse<InforClass>;

            // Assert
            Assert.False(value.DidError);
        }

    }
}