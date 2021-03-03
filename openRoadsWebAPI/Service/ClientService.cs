using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using openRoads.Model;
using openRoads.Model.Requests;
using openRoadsWebAPI.Helpers;
using openRoadsWebAPI.Models;

namespace openRoadsWebAPI.Service
{
    public class ClientService : BaseCRUDService<ClientModel, ClientSearchRequest, Client, ClientUpdateRequest, ClientUpdateRequest>
    {

        public ClientService(MyDbContext context, IMapper mapper) : base(context, mapper)
        {
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

            return _mapper.Map<List<ClientModel>>(clientList);

        }

        public override ClientModel Update(int id, ClientUpdateRequest request)
        {
            var clientForUpdate = _context.Client.FirstOrDefault(x => x.ClientId == id);
            var personForUpdate = _context.Person.FirstOrDefault(x => x.PersonId == clientForUpdate.PersonId);
            var loginDataList = _context.LoginData.ToList();

            if (personForUpdate != null)
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
                    }
                }
            }

            _context.SaveChanges();

            return _mapper.Map<ClientModel>(clientForUpdate);
        }
    }
}
