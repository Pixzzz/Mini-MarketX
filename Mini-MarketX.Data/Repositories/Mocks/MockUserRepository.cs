using Mini_MarketX.Data.Interfaces;
using Mini_MarketX.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_MarketX.Data.Exceptions;

namespace Mini_MarketX.Data.Repositories.Mocks
{
    public class MockUserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public void Add(User user)
        {
            if (_users.Any(u => u.Email == user.Email))
            {
                throw new CorreoEnUsoException($"El correo electrónico {user.Email} ya está en uso.");
            }
            _users.Add(user);
        }


        public void Update(User user)
        {
            if (user == null)
            {
                throw new UsuarioNoEncontrdoException("El usuario no puede ser nulo.");
            }

            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser == null)
            {
                throw new UsuarioNoEncontrdoException($"Usuario con ID {user.Id} no encontrado.");
            }

            
            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
        }


        public void Remove(User user)
        {
            if (user == null || !_users.Any(u => u.Id == user.Id))
            {
                throw new UsuarioNoEncontrdoException($"Usuario con ID {user?.Id} no encontrado.");
            }
            _users.Remove(user);
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public User GetById(int userId)
        {
            var user = _users.SingleOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new UsuarioNoEncontrdoException("El usuario no fue encontrado.");
            }

            if (!user.IsActive)
            {
                throw new UsuarioInactivoException("El usuario está inactivo.");
            }

            return user;
        }

        public User GetByEmail(string email)
        {
            var user = _users.SingleOrDefault(u => u.Email == email);
            if (user == null)
            {
                throw new CorreoNoExisteException($"Usuario con correo electrónico '{email}' no encontrado.");
            }
            return user;
        }
    }
}
