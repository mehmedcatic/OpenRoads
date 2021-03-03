using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using openRoadsWebAPI.Helpers;
using openRoadsWebAPI.Models;

namespace openRoadsWebAPI.Service
{
    public class BaseCRUDService<TModel, TSearch, TDatabase, TInsert, TUpdate> : BaseService<TModel, TSearch, TDatabase> , 
         IBaseCRUDService<TModel, TSearch, TInsert, TUpdate> where TDatabase : class
    {
        public BaseCRUDService(MyDbContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public virtual TModel Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual TModel Insert(TInsert request)
        {
            var entity = _mapper.Map<TDatabase>(request);

            _context.Set<TDatabase>().Add(entity);
            _context.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Update(int id, TUpdate request)
        {
            var entity = _context.Set<TDatabase>().Find(id);

            _context.Set<TDatabase>().Attach(entity);
            _context.Set<TDatabase>().Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<TModel>(entity);
        }

        
    }
}
