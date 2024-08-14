using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Validation.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_AGENDAMED.Domain.Test.Validator.user
{
    public class ValidatorTest
    {
        [Fact]
        public void IsNotValidUser()
        {

            var newUser = new User();


            var validator = new UserValidator();

            var result = validator.Validate(newUser);

            Assert.False(result.IsValid);



        }

        [Fact]
        public void IsValidUser()
        {

            var newUser = new User() { Name = "Teste", LastName = "Teste 1"};


            var validator = new UserValidator();

            var result = validator.Validate(newUser);

            Assert.True(result.IsValid, "Mensagem: " + string.Join(", ", result.Errors.Select(obj => obj.ErrorMessage)));


        }
    }
}
