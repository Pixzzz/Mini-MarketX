using Moq;
using Mini_MarketX.Data.Entities;
using Mini_MarketX.Data.Repositories.Db;
using Mini_MarketX.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Mini_MarketX.Data.Context;
using Mini_MarketX.Data.Repositories.Mocks;
using Mini_MarketX.Data.Exceptions;

namespace Mini_MarketX.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Update_Throws_UsuarioNoEncontradoException_When_User_Is_Null()
        {
            // Arrange
            var repository = new MockUserRepository();

            // Act
            User user = null;

            // Assert
            Assert.Throws<UsuarioNoEncontrdoException>(() => repository.Update(user));
        }

        [Fact]
        public void Add_Throws_CorreoEnUsoException_When_Email_Already_In_Use()
        {
            // Arrange
            var repository = new MockUserRepository(); 
            var existingUser = new User
            {
                Id = 1,
                Username = "existinguser",
                Email = "existinguser@example.com",
                Password = "password123"
            };
            repository.Add(existingUser);

            var newUser = new User
            {
                Id = 2,
                Username = "newuser",
                Email = "existinguser@example.com", 
                Password = "newpassword"
            };

            // Act y Assert
            Assert.Throws<CorreoEnUsoException>(() => repository.Add(newUser));
        }
        [Fact]
        public void Remove_Throws_UsuarioNoEncontradoException_When_User_Not_Found()
        {
            // Arrange
            var repository = new MockUserRepository(); 
            var nonExistentUser = new User
            {
                Id = 99, // Un ID que no existe
                Username = "nonexistentuser",
                Email = "nonexistentuser@example.com",
                Password = "password123"
            };

            // Act y Assert
            Assert.Throws<UsuarioNoEncontrdoException>(() => repository.Remove(nonExistentUser));
        }

        [Fact]
        public void GetById_Throws_UsuarioInactivoException_When_User_Is_Not_Active()
        {
            // Arrange
            var repository = new MockUserRepository(); 
            var inactiveUser = new User
            {
                Id = 1,
                Username = "inactiveuser",
                Email = "inactiveuser@example.com",
                Password = "password123",
                IsActive = false // Usuario inactivo
            };
            repository.Add(inactiveUser);

            // Act y Assert
            Assert.Throws<UsuarioInactivoException>(() => repository.GetById(inactiveUser.Id));
        }

        [Fact]
        public void GetByEmail_Throws_UsuarioNoEncontradoException_When_Email_Not_Found()
        {
            // Arrange
            var repository = new MockUserRepository(); 

            // Act 
            string nonExistentEmail = "nonexistentuser@example.com";
            // Assert
            Assert.Throws<CorreoNoExisteException>(() => repository.GetByEmail(nonExistentEmail));
        }
    }
}