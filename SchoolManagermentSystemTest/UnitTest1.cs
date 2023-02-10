using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SampleSchoolManagermentV1.Validation.FluentValidation;
using FluentValidation.TestHelper;
namespace SchoolManagermentSystemTest
{
    public class UnitTest1
    {
        private readonly ClassValidator _validator = new ClassValidator();

        [Fact]
        public void GivenAnInvalidClassNameValue_ShouldHaveValidationError()
        {
            _validator.ShouldHaveChildValidator(model => model.ClassName, typeof(ClassValidator));
        }
       
    }
}