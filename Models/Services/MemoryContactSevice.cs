namespace Project.Models.Services;

public class MemoryContactService:IContactService
{
    private Dictionary<int, ContactModel> _contacts = new Dictionary<int, ContactModel>()
    {
        {
            1,
            new()
            {
                Id = 1, Email = "jjjjj@gmail.com", FirstName = "Jakub", LastName = "Putowski", Category = Category.Family,
                BirthDate = new DateTime(1980, 10, 10), PhoneNumber = "222 222 222"
            }
        },
        {
            2,
            new()
            {
                Id = 2, Email = "jakub@wsei.com", FirstName = "Marian", LastName = "Kowalski",
                BirthDate = new DateTime(1970, 10, 10), PhoneNumber = "111 111 111"
            }
        }
    };
    private int currentID = 3;
    public void Add(ContactModel model)
    {
        model.Id = ++currentID;
        _contacts.Add(model.Id, model);
    }

    public void Update(ContactModel contact)
    {
        if (_contacts.ContainsKey(contact.Id))
        {
            _contacts[contact.Id] = contact;
        }
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        return _contacts[id];
    }

    public List<OrganizationEntity> findAllOrganizations()
    {
        throw new NotImplementedException();
    }
}