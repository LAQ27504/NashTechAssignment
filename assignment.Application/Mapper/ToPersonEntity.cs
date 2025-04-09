using assignment.Domain.Entities;
using assignment.Application.DTOs;

namespace assignment.Application.Mapper
{
    public static class ToPersonEntity
    {
        public static Person ToEntity(PersonConfigRequest model)
        {
            return new Person(
                model.FirstName,
                model.LastName,
                model.DateOfBirth,
                model.Gender,
                model.BirthPlace
            );
        }
    }
}