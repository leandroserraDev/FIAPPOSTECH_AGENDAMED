using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Entities.user.doctor;
using AGENDAMED.Domain.Interface.Repositories.speciality;
using AGENDAMED.Domain.Interface.Repositories.user;
using AGENDAMED.Domain.Interface.Repositories.user.doctor.schedule;
using AGENDAMED.Domain.Interface.Services.notification;
using AGENDAMED.Domain.Interface.Services.user;
using AGENDAMED.Domain.ValueObject;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AGENDAMED.Services.Services.user
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationErrorService _notificationErrorService;
        private readonly IDoctorSpecialityRepository _doctorSpecialityRepository;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepository userRepository,
                           UserManager<User> userManager,
                           INotificationErrorService notificationErrorService,
                           IDoctorSpecialityRepository doctorSpecialityRepository)
            : base(userRepository)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _notificationErrorService = notificationErrorService;
            _doctorSpecialityRepository = doctorSpecialityRepository;
        }

        public async Task<List<User>> GetUsersDoctor()
        {
            return await _userRepository.GetUsersDoctor();
        }

        public async Task<List<User>> GetUsersPatients()
        {
            return await _userRepository.GetUsersPatients();

        }

        public override async Task<User> Create(User entity)
        {

            if (entity == null) throw new ArgumentNullException();

            var _randonPasswordToDoctor = new Random().Next(12, 553) + "" + Guid.NewGuid().ToString().Substring(0, 8);
            _randonPasswordToDoctor.Reverse();
            var userBD = await _userManager.FindByEmailAsync(entity.Email);

            if(userBD != null)
            {
                //TO DO
                // Validar se usuário já está cadastrado como Doutor no sistema

                await _notificationErrorService.AddNotification(new("Usuário já cadastrado"));

                return null;
            }


            await _userManager.CreateAsync(entity);

            return await Task.FromResult(entity);
        }

        public async Task<User> CreatePatient(User user, string password)
        {
            if (user == null) throw new ArgumentNullException();

            var _randonPasswordToDoctor = new Random().Next(12, 553) + "" + Guid.NewGuid().ToString().Substring(0, 8);
            _randonPasswordToDoctor.Reverse();
            var userBD = await _userManager.FindByEmailAsync(user.Email);

            if (userBD != null)
            {
                //TO DO
                // Validar se usuário já está cadastrado como Doutor no sistema

                await _notificationErrorService.AddNotification(new("Usuário já cadastrado"));
                return null;
            }


            await _userManager.CreateAsync(user);

            return await Task.FromResult(user);
        }

        public Task<User> UpdatePatient(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeletePatient(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> CreateDoctor(User user)
        {
            IdentityResult? result = null;
            if (user == null) throw new ArgumentNullException();

            var userBD = await _userManager.FindByEmailAsync(user.Email);
            if (userBD != null)
            {
                //TO DO
                // Validar se usuário já está cadastrado como Doutor no sistema
                var isDoctor = await _userRepository.GetUserDoctor(userBD.Id);
                if(isDoctor != null)
                {

                    await _notificationErrorService.AddNotification(new("Usuário já cadastrado"));
                    return null;

                }
                return userBD;
            }

            var password = GeneratePassword();
            result =  await _userManager.CreateAsync(user, password);
            if(!result.Succeeded)
            {
                return null;
            }
            await _userManager.AddToRoleAsync(user, "Doctor");

            //enviar email para o doutor com a senha.....

            return await _userRepository.GetUserDoctorEmail(user.Email);
        }

        public async Task<User> UpdateDoctor(string id,User user)
        {
            var userBD = await _userRepository.GetUserDoctor(id);

            if(userBD == null)
            {
                return null;
            }


            userBD.Name = user.Name;
            userBD.LastName = user.LastName;
            //await _doctorSpecialityRepository.DeleteSpecialtyDoctor(userBD.Id);

            var result = await _userRepository.Update(userBD);


            if (result == null)
            {
                return null;
                
            }

            if (!await _userManager.IsInRoleAsync(userBD, "Doctor"))
            {
                await _userManager.AddToRoleAsync(userBD, "Doctor");
            }

            return await _userRepository.GetUserDoctorEmail(userBD.Email);

        }

        public Task<User> DeleteDoctor(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetDoctorById(string id)
        {
            var result = await _userRepository.GetUserDoctor(id);

            return await Task.FromResult(result);
        }

        public Task<User> GetPatientById(string id)
        {
            throw new NotImplementedException();
        }

        private string GeneratePassword()
        {
            string passwordOptions = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";

            string password = "";
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            do
            {
                password = new string(Enumerable.Repeat(passwordOptions, 8).Select(s => s[RandomNumberGenerator.GetInt32(s.Length)]).ToArray());

            }
            while (regexItem.IsMatch(password));

            return password;
        }
    }
}
