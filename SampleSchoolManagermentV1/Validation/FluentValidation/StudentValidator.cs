﻿using FluentValidation;
using SampleSchoolManagermentV1.DTO;

namespace SampleSchoolManagermentV1.Model.FluentValidation
{
    public class StudentValidator : AbstractValidator<CreateStudentDTO>
    {
        public StudentValidator() { 
            RuleFor(x=>x.StudentName).NotEmpty().NotNull().Length(5,100);
        }
    }
}
