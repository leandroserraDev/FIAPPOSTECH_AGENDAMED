using AGENDAMED.Domain.Entities.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGENDAMED.Application.DTOs.user.auth
{
    public class UserAuthViewModel
    {

        public UserAuthViewModel(User user )
        {
            Id = user.Id;
            Nome = user.Name;
            Sobrenome = user.LastName;
            Email = user.Email;
        }
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }

        public User ToDomain()
        {
            var domain = new User() { Id = Id };
            return domain;
        }
    }
}
