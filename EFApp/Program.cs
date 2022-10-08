using Aeon.DataModels;
using ChillChat.DataModels;
using ChillChat.Services;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var repository = new ChillChatDbRepository();
ServerService service = new ServerService(repository);
var model = new ServerViewModel
{
    Name = "asd",
    ObjectInfo = new ObjectInfo()
};
var message = service.Save(model);

repository.SaveChanges();