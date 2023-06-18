namespace ProfileManagement.Models
{
    public interface IProfileDetails
    { 
        ProfileDetails GetDetails(int Id);
        IEnumerable<ProfileDetails> GetAllDetails();
        ProfileDetails Add(ProfileDetails profileDetails);
        ProfileDetails Update(ProfileDetails proDetailsChanges);
        ProfileDetails Delete(int id);
     } 
} 