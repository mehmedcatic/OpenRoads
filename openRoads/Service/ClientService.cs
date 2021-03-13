using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Windows.Forms;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using openRoads.Model;
using openRoads.Model.Requests;
using openRoadsWebAPI.Exceptions;
using openRoadsWebAPI.Helpers;
using openRoadsWebAPI.Models;

namespace openRoadsWebAPI.Service
{
    public class ClientService : BaseCRUDService<ClientModel, ClientSearchRequest, Client, ClientUpdateRequest, ClientUpdateRequest>
    {

        public ClientService(MyDbContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public override ClientModel AuthenticateClient(string username, string password)
        {
            var loginDataUser = _context.LoginData.FirstOrDefault(x => x.Username == username);
            var person = _context.Person.FirstOrDefault(x => x.LoginDataId == loginDataUser.LoginDataId);
            var client = _context.Client.FirstOrDefault(x => x.PersonId == person.PersonId);

            if (client != null)
            {
                var newHash = HelperClass.GenerateHash(loginDataUser.PasswordSalt, password);

                if (newHash == loginDataUser.PasswordHash)
                {
                    return _mapper.Map<ClientModel>(client);
                }
            }

            return null;
        }

        public override List<ClientModel> Get(ClientSearchRequest search)
        {
            var clientList = _context.Client.Include(x=>x.Person).ToList();

            if (search.CountryId.HasValue)
            {
                var countriesList = _context.Country.ToList();

                var filteredClients = new List<Client>();

                foreach (var x in clientList)
                {
                    if (x.Person.CountryId == search.CountryId)
                        filteredClients.Add(new Client
                        {
                            PersonId = x.PersonId,
                            Active = x.Active,
                            ClientId = x.ClientId,
                            RegistrationDate = x.RegistrationDate
                        });
                }
                return _mapper.Map<List<ClientModel>>(filteredClients);
            }

            
            if (string.IsNullOrEmpty(search.Username) == false)
            {
                var persons = _context.Person.ToList();
                var loginModel = _context.LoginData.FirstOrDefault(x => x.Username == search.Username);

                List<ClientModel> client = new List<ClientModel>();
                foreach (var x in clientList)
                {
                    foreach (var person in persons)
                    {
                        if (x.PersonId == person.PersonId)
                        {
                            if(person.LoginDataId == loginModel.LoginDataId && loginModel.Username == search.Username)
                                client.Add(new ClientModel
                                {
                                    Active = x.Active,
                                    PersonId = x.PersonId,
                                    ClientId = x.ClientId,
                                    RegistrationDate = x.RegistrationDate
                                });

                        }
                    }
                }

                if (client.Count > 0)
                    return _mapper.Map<List<ClientModel>>(client);

                return null;

            }

            return _mapper.Map<List<ClientModel>>(clientList);

        }

        public override ClientModel Insert(ClientUpdateRequest request)
        {
            var LoginDataCheck = _context.LoginData.FirstOrDefault(x => x.Username == request.Username);
            if (LoginDataCheck != null)
                throw new UserException("Username already exists, try another one!");

            var personCheck = _context.Person.FirstOrDefault(x => x.Email == request.Email);
            if (personCheck != null)
                throw new UserException("Email already exists, try another one!");

            request.PasswordSalt = HelperClass.GenerateSalt();
            request.PasswordHash = HelperClass.GenerateHash(request.PasswordSalt, request.CleasPassword);

            LoginData newData = new LoginData
            {
                Username = request.Username,
                PasswordSalt = request.PasswordSalt,
                PasswordHash = request.PasswordHash
            };

            _context.LoginData.Add(newData);
            _context.SaveChanges();

            Person newPerson = new Person
            {
                Address = request.Address,
                City = request.City,
                CountryId = request.CountryId,
                DateOfBirth = request.DateOfBirth,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                LoginDataId = newData.LoginDataId
            };

            _context.Add(newPerson);
            _context.SaveChanges();

            //byte[] userProfilePic = request.ProfilePicture;

            Client newClient = new Client
            {
                PersonId = newPerson.PersonId,
                Active = true,
                RegistrationDate = DateTime.Now,
                ProfilePicture = request.ProfilePicture
            };

            _context.Client.Add(newClient);
            _context.SaveChanges();

            return _mapper.Map<ClientModel>(newClient);
        }

        public override ClientModel Update(int id, ClientUpdateRequest request)
        {
            try
            {
                var clientForUpdate = _context.Client.FirstOrDefault(x => x.ClientId == id);
                var personForUpdate = _context.Person.FirstOrDefault(x => x.PersonId == clientForUpdate.PersonId);
                var loginDataList = _context.LoginData.ToList();

                if (personForUpdate != null)
                {
                    if (request.ProfilePicture != null)
                        clientForUpdate.ProfilePicture = request.ProfilePicture;

                    else
                    {
                        personForUpdate.CountryId = request.CountryId;
                        personForUpdate.LastName = request.LastName;
                        personForUpdate.FirstName = request.FirstName;
                        personForUpdate.Address = request.Address;
                        personForUpdate.City = request.City;
                        personForUpdate.DateOfBirth = request.DateOfBirth;
                        personForUpdate.Email = request.Email;
                        personForUpdate.PhoneNumber = request.PhoneNumber;

                        foreach (var x in loginDataList)
                        {
                            if (x.LoginDataId == personForUpdate.LoginDataId)
                            {
                                x.PasswordSalt = HelperClass.GenerateSalt();
                                x.PasswordHash = HelperClass.GenerateHash(x.PasswordSalt, request.CleasPassword);
                                x.Username = request.Username;

                                break;
                            }
                        }
                    }

                }

                _context.SaveChanges();

                return _mapper.Map<ClientModel>(clientForUpdate);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
