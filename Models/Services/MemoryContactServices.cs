namespace Project.Models.Services;

public class MemoryContactService: iContactService
{
    private Dictionary<int, ContactModel> _contacts= new Dictionary<int, ContactModel>()
    {
        {1, new() {Id = 1, Email = "email@wsei.com",FirstName = "Jakub", LastName = "Putowski", Category = Category.Business, BirthDate = new (1990, 11,05), PhoneNumber = "111 111 111"}},
        {2, new() {Id = 2, Email = "email1@wsei.com",FirstName = "Karol", LastName = "Kowal", Category  = Category.Family, BirthDate = new DateTime(1950, 03,17), PhoneNumber = "222 222 222"}}
    };

    private int _currentId = 3;
    
    public void Add(ContactModel model)
    {
        model.Id = ++_currentId;
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
        // return _contacts.TryGetValue(id, out var contact) ? contact : null;
        return _contacts[id];
    }
}