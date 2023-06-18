namespace ProfileManagement.Models
{
    public class ProfilePageDetails : IProfileDetails
    {  
        private List<ProfileDetails> _profileDetailsList;
        public ProfilePageDetails()
        {
            _profileDetailsList = new List<ProfileDetails>()
            {
                new ProfileDetails() { Id = 1, Name = "John", Email = "john@gmail.com", Department = Dept.HR, Skills = "Writing", Experience = "3 years", Projects = ""},
                new ProfileDetails() { Id = 2, Name = "Dane", Email = "dane@gmail.com", Department = Dept.IT, Skills = "Singing", Experience = "4 years", Projects = ""},
                new ProfileDetails() { Id = 3, Name = "Mee", Email = "mee@gmail.com", Department = Dept.Sales, Skills = "Coding", Experience = "1 year", Projects = ""} 
            };
        }

        public ProfileDetails Add(ProfileDetails profileDetails)
        {
            profileDetails.Id = _profileDetailsList.Max(e => e.Id) + 1;
            _profileDetailsList.Add(profileDetails);
            return profileDetails;     
        }

        public ProfileDetails Delete(int id)
        {
            ProfileDetails profileDetails = _profileDetailsList.FirstOrDefault(e => e.Id == id);
            if(profileDetails != null)
            {
                _profileDetailsList.Remove(profileDetails);
            }
            return profileDetails;
        }

        public IEnumerable<ProfileDetails> GetAllDetails()
        {
            return _profileDetailsList;
        }
        public ProfileDetails GetDetails(int Id)
        {
            return _profileDetailsList.FirstOrDefault(e => e.Id == Id);
        }

        public ProfileDetails Update(ProfileDetails proDetailsChanges)
        {
            ProfileDetails profileDetails = _profileDetailsList.FirstOrDefault(e => e.Id == proDetailsChanges.Id);
            if(profileDetails != null)
            {
                profileDetails.Name = proDetailsChanges.Name;
                profileDetails.Email = proDetailsChanges.Email;
                profileDetails.Department = proDetailsChanges.Department;
                profileDetails.Skills = proDetailsChanges.Skills;
                profileDetails.Projects = proDetailsChanges.Experience;
                profileDetails.Experience = proDetailsChanges.Experience;
            }
            return profileDetails;
        }
    }
}