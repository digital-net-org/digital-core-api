﻿using Digital.Net.Core.Random;
using Digital.Net.Entities.Repositories;
using Digital.Net.TestTools.Data.Factories;
using SafariDigital.Data.Models.Database.Users;

namespace Tests.Utils.Factories;

public class UserFactory(IRepository<User> repository)
{
    private readonly DataFactory<User> _userFactory = new(repository);
    public void Dispose() => _userFactory.Dispose();

    public (User, string) CreateUser(UserPayload? userPayload = null)
    {
        var password = Randomizer.GenerateRandomString();
        var user = UserFactoryUtils.CreateUser();
        if (userPayload is not null) user.Update(userPayload);

        user.Update(new UserPayload { Password = password });
        var created = _userFactory.Create(user);
        return (created, password);
    }

    public List<User> CreateManyUsers(int count)
    {
        var users = UserFactoryUtils.CreateManyUsers(count);
        return users.Select(user => _userFactory.Create(user)).ToList();
    }
}