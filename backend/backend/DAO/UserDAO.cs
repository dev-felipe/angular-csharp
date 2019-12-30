using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DAO
{
    public class UserDAO
    {
        private Context _context;

        public UserDAO(Context context)
        {
            _context = context;
        }

        internal List<User> FindAll()
        {
            try
            {
                return _context.users.Where(x => x.Id != 0).ToList();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        internal User FindById(int id)
        {
            try
            {
               return _context.users.FirstOrDefault(x => x.Id.Equals(id));
            }
            catch (Exception e)
            {

                throw;
            }
        }

        internal bool Save(User user)
        {
            try
            {
                _context.users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }

        internal int FindByEmail(string email)
        {
            try
            {
                if (_context.users.FirstOrDefault(x => x.email.Equals(email)) != null)
                {
                    return 0;
                } else
                {
                    return 1;
                }

            }
            catch (Exception e)
            {
                return 2;
                throw;
            }
        }

        internal int Delete(int id)
        {
            try
            {
                User user = new User();
                user = FindById(id);

                if (user != null)
                {
                    _context.Remove(user);
                    _context.SaveChanges();
                    return 0;
                }

                return 1;
                
            }
            catch (Exception)
            {
                return 2;
                throw;
            }
        }

        internal int Update(User user)
        {
            try
            {
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                return 1;
                throw;
            }
        } 
    }
}
