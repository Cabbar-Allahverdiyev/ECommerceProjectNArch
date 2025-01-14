using Core.Security.Entities;
using Core.Test.Application.FakeData;
using System;
using System.Collections.Generic;

namespace Application.Tests.Mocks.FakeData;

public class UserFakeData : BaseFakeData<User, int>
{
    public static readonly List<User> Seeds = new List<User>()
    {
        new ()
        {
            Id = 1,
            FirstName = "Cabbar",
            LastName = "Allahverdiyev",
            Email = "example@email.com",
            PasswordHash = new byte[] { },
            PasswordSalt = new byte[] { },
            Status = true,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now
        },
        new ()
        {
            Id =2,
            FirstName = "Seymur",
            LastName = "Veliyev",
            Email = "example2@email.com",
            PasswordHash = new byte[] { },
            PasswordSalt = new byte[] { },
            Status = true,
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now
        }

    };
    public override List<User> CreateFakeData() => Seeds;
}
