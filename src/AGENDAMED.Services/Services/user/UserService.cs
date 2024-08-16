using AGENDAMED.Domain.Entities.user;
using AGENDAMED.Domain.Entities.user.doctor;
using AGENDAMED.Domain.Entities.user.patient;
using AGENDAMED.Domain.Enums;
using AGENDAMED.Domain.Interface.Repositories.speciality;
using AGENDAMED.Domain.Interface.Repositories.user;
using AGENDAMED.Domain.Interface.Repositories.user.doctor.schedule;
using AGENDAMED.Domain.Interface.Services.email.doctor.email;
using AGENDAMED.Domain.Interface.Services.loggedUser;
using AGENDAMED.Domain.Interface.Services.notification;
using AGENDAMED.Domain.Interface.Services.user;
using AGENDAMED.Domain.ValueObject;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        private readonly ILoggedUserService _loggedUserService;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepository userRepository,
                           UserManager<User> userManager,
                           INotificationErrorService notificationErrorService,
                           IDoctorSpecialityRepository doctorSpecialityRepository,
                           IConfiguration configuration,
                           ILoggedUserService loggedUserService)
            : base(userRepository)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _notificationErrorService = notificationErrorService;
            _doctorSpecialityRepository = doctorSpecialityRepository;
            _configuration = configuration;
            _loggedUserService = loggedUserService;
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

            user.Patient = new Patient();

           var result =  await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                result.Errors.ToList().ForEach(obj =>
                {
                    _notificationErrorService.AddNotification(obj.Description);

                });
                return null;
            }
            await _userManager.AddToRoleAsync(user, ERoles.Patient.ToString());

            return await Task.FromResult(user);
        }

        public async  Task<User> UpdatePatient(User user)
        {
           var userBD = await _userManager.FindByEmailAsync(user.Email);
            if (userBD == null)
            {
                await _notificationErrorService.AddNotification("Usuário não encontrado");
                return null;

            }

            if (!userBD.Id.Equals(_loggedUserService.LoggedUser().Result.Id))
            {
                await _notificationErrorService.AddNotification("Não permitido");
                return null;

            }
            var result = await _userRepository.Update(userBD);
            if (result == null)
            {
                return null;
            }

            return await Task.FromResult(user);


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
                var isDoctor = await _userRepository.GetUserDoctorById(userBD.Id);
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

                result.Errors.ToList().ForEach(obj =>
                {
                    _notificationErrorService.AddNotification(new(obj.Description));

                });
                return null;
            }
            await _userManager.AddToRoleAsync(user, "Doctor");

            //enviar email para o doutor com a senha.....
            var emailCreate = new EmailCreateDoctor(user.Email,
                $"Foi criado uma conta para você: Sua senha para acesso ao sistema: {password}", "Senha de acesso", _configuration);
            emailCreate.SendEmail();
            return await _userRepository.GetUserDoctorEmail(user.Email);
        }

        public async Task<User> UpdateDoctor(string id,User user)
        {
            var userBD = await _userRepository.GetUserDoctorById(id);

            if(userBD == null)
            {
                return null;
            }


            userBD.Name = user.Name;
            userBD.LastName = user.LastName;
            userBD.Doctor.CRM = user.Doctor.CRM;
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
            var result = await _userRepository.GetUserDoctorById(id);

            return await Task.FromResult(result);
        }

        public async Task<User> GetPatientById(string id)
        {
            var result = await _userRepository.GetUserById(id);

            return await Task.FromResult(result);
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

        public async Task<User> GetUserDoctorById(string doctorID)
        {
            var result = await _userRepository.GetUserDoctorById(doctorID);
            return await Task.FromResult(result);
        }

        public async Task<List<User>> GetActiveBySpecialityID(long specialityID)
        {
            return await _userRepository.GetActiveBySpecialityID(specialityID);
        }
    }
}
