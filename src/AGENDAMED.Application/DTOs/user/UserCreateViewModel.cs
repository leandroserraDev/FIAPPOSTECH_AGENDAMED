using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.user
{
    public class UserCreateViewModel
    {
        public UserCreateViewModel(string nome, string sobrenome, string email, string password, ERoles role = default)
        {
            Nome = nome;
            SobreNome = sobrenome;
            Email = email;
            Password = password;
            Role = role;
        }

        public string Nome { get; set; }
        public string SobreNome{ get; set; }

        public string Email { get; set; }
        public ERoles Role { get; set; }
        public string Password { get; set; }


        public virtual User ToDomain()
        {
            var newUser = new User() { UserName = Nome,Email = Email};

            return newUser;

        }

    }
    
}
