using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Interface.Services.email.doctor.email;
using AGENDAMED.Domain.Interface.Services.email.emailBase;
using AGENDAMED.Domain.Validation.email;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_AGENDAMED.Domain.Test.Validator.email
{
    public class ValidatorTest
    {

        [Fact]
        public void IsNotValid()
        {

            var newUser = new EmailCreateDoctor("", "", "", null);


            var validator = new EmailValidator();


            var result = validator.Validate(newUser);

            Assert.False(result.IsValid);



        }

        [Fact]
        public void IsValid()
        {


            var newEmail = new EmailCreateDoctor("213213321", "32321321321", "13231213212312", null);


            var validator = new EmailValidator();


            var result = validator.Validate(newEmail);

            Assert.True(result.IsValid, "Mensagem: " + string.Join(", ", result.Errors.Select(obj => obj.ErrorMessage)));


        }
    }
}
