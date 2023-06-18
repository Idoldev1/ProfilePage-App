using ProfileManagement.Models;
using Microsoft.Extensions.Logging;


namespace ProfileManagement.Data
{
    public class SqliteRepository : IProfileDetails
    {
        private readonly ProfileDetailsContext context;
        private readonly ILogger logger;

        public SqliteRepository(ProfileDetailsContext context,
                                ILogger<SqliteRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }


        public ProfileDetails Add(ProfileDetails profileDetails)
        {
            context.ProfileDetail.Add(profileDetails);
            context.SaveChanges();
            return profileDetails;
        }

        public ProfileDetails Delete(int id)
        {
            ProfileDetails profileDetails = context.ProfileDetail.Find(id);
            if (profileDetails != null)
            {
                context.ProfileDetail.Remove(profileDetails);
                context.SaveChanges();
            }
            return profileDetails;
        }

        public IEnumerable<ProfileDetails> GetAllDetails()
        {
            return context.ProfileDetail; 
        }

        public ProfileDetails GetDetails(int Id)
        {
            return context.ProfileDetail.Find(Id);
        }

        public ProfileDetails Update(ProfileDetails proDetailsChanges)
        {
            var updateDetails = context.ProfileDetail.Attach(proDetailsChanges);
            updateDetails.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return proDetailsChanges;
        }
    }
}