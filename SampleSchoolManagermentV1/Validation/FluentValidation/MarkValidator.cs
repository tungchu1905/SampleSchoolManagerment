using FluentValidation;
using SampleSchoolManagermentV1.DTO;

namespace SampleSchoolManagermentV1.Validation.FluentValidation
{
    public class MarkValidator : AbstractValidator<MarkDTO>
    {
        public MarkValidator() { 
            RuleFor(x => x.Mark).LessThanOrEqualTo(10).GreaterThanOrEqualTo(0).WithMessage("Pls mark must [0,10]");
        }
    }
}
