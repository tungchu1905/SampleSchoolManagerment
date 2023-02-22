using SampleSchoolManagermentV1.Datas;
using SampleSchoolManagermentV1.DTO;
using SampleSchoolManagermentV1.Entities;
using SampleSchoolManagermentV1.Services.Interfaces;
using SampleSchoolManagermentV1.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagermentSystemTest
{
    public static class StudentClassServiceFake
    {
        public static void Seed(this SchoolContext schoolContext)
        {
            schoolContext.informationClass.Add(new InforClass
            {
                Id = 1,
                ClassName = "Test 1A",
                Grade = 1,
                TeacherName = "Tung Chu"
            });
            schoolContext.informationClass.Add(new InforClass
            {
                Id = 2,
                ClassName = "Test 2A",
                Grade = 2,
                TeacherName = "Tung Chu"
            });
            schoolContext.informationClass.Add(new InforClass
            {
                Id = 3,
                ClassName = "Test 3A",
                Grade = 3,
                TeacherName = "Tung Chu"
            });
            schoolContext.informationClass.Add(new InforClass
            {
                Id = 4,
                ClassName = "Test 4A",
                Grade = 4,
                TeacherName = "Tung Chu"
            });
            schoolContext.informationClass.Add(new InforClass
            {
                Id = 5,
                ClassName = "Test 5A",
                Grade = 5,
                TeacherName = "Tung Chu"
            });
            schoolContext.informationClass.Add(new InforClass
            {
                Id = 6,
                ClassName = "Test 6A",
                Grade = 6,
                TeacherName = "Tung Chu"
            });
        }


    }
}
