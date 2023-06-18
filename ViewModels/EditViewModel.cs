namespace ProfileManagement.ViewModels
{
    public class EditViewModel : ProfileCreateView
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }
    }
}