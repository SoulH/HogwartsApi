using Core;
using System;
using Xunit;

namespace QA
{
    public class UnitTest1
    {
        [Fact]
        public void ValidationTest()
        {
            var err = new Registration { 
                Name = "012345678901234567890",
                LastName = "Nuñez",
                Age = 100,
                Identification = 10000000000,
                House = "Playboy"
            }.Validate();
            Assert.True(err.ContainsKey("Name"), "Debe fallar");
            Assert.True(err["Name"].Length == 2, "Debe indicar error por ser numerico y error por tener mas de 20 caracteres");
            Assert.True(!err.ContainsKey("LastName"), "Debe permitir caracteres especiales");
            Assert.True(err.ContainsKey("Age"), "Debe indicar error por tener mas de 2 caracteres");
            Assert.True(err.ContainsKey("Identification"), "Debe indicar error por tener mas de 20 caracteres");
            Assert.True(err.ContainsKey("House"), "Playboy no es uno de los valores válidos");
        }
    }
}
