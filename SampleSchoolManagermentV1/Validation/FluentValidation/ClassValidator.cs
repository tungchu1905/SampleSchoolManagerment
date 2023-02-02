using FluentValidation;
using SampleSchoolManagermentV1.DTO;

namespace SampleSchoolManagermentV1.Model.FluentValidation
{
    public class ClassValidator : AbstractValidator<CreateClassDTO>
    {
        public ClassValidator()
        {
            RuleFor(x => x.ClassName).NotEmpty().NotNull().WithMessage("Enter full");
            RuleFor(x => x.Grade).LessThan(13).GreaterThan(0);
        }
    }
}
