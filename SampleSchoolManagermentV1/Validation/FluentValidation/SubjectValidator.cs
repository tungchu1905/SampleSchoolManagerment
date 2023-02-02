using FluentValidation;
using SampleSchoolManagermentV1.DTO;

namespace SampleSchoolManagermentV1.Model.FluentValidation
{
    public class SubjectValidator  : AbstractValidator<CreateSubjectDTO>
    {
        public SubjectValidator() { 
            RuleFor(x=>x.SubjectName).NotEmpty().NotNull();
            RuleFor(x=>x.Semester).NotEmpty().NotNull().LessThan(3).GreaterThan(0);
            RuleFor(x=>x.Grade).NotEmpty().NotNull().LessThan(13).GreaterThan(0);
        }
    }
}
