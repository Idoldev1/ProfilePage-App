using Microsoft.AspNetCore.Mvc;
using ProfileManagement.ViewModels;
using ProfileManagement.Models;
 

namespace ProfileManagement.Controllers;

public class HomeController : Controller
{ 
    private readonly IProfileDetails _profileDetails;
    private readonly IWebHostEnvironment webHostEnvironment;

    public HomeController(IProfileDetails profile, IWebHostEnvironment webHostEnvironment)
    {
        _profileDetails = profile;
        this.webHostEnvironment = webHostEnvironment;
    }




    [HttpGet]
    public ViewResult Index()
    {
        var model = _profileDetails.GetAllDetails();
        return View(model);
    }


    
    [HttpGet]
     public ViewResult Details(int? id)
    {
        ProfileDetails profileDetails = _profileDetails.GetDetails(id.Value);

        if (profileDetails == null)
        {
            Response.StatusCode = 404;
            return View("NotFound", id.Value);
        } 

        HomeDetailsView homeDetailsView = new HomeDetailsView()
        {
            ProfileDetails = _profileDetails.GetDetails(id??1),
            PageTitle = "User Details"
        };
         
        return View(homeDetailsView);
    }


    [HttpGet]
    public ViewResult NewProfile()
    {
        return View();
    }


    [HttpGet]
    public ViewResult Edit(int id)
    { 
        ProfileDetails profileDetails = _profileDetails.GetDetails(id);
        EditViewModel editViewModel = new EditViewModel
        {
            Id = profileDetails.Id,
            Name = profileDetails.Name,
            Email = profileDetails.Email,
            Department = profileDetails.Department,
            Skills = profileDetails.Skills,
            Projects = profileDetails.Projects,
            Experience = profileDetails.Experience,
            ExistingPhotoPath = profileDetails.PhotoPath
        }; 
        return View(editViewModel);
    }


    [HttpPost]
    public IActionResult Edit(EditViewModel model)
    {
        if (ModelState.IsValid) 
        { 
            ProfileDetails profileDetails = _profileDetails.GetDetails(model.Id);
            profileDetails.Name = model.Name;
            profileDetails.Email = model.Email;
            profileDetails.Department = model.Department;
            profileDetails.Skills = model.Skills;
            profileDetails.Experience = model.Experience;
            profileDetails.Projects = model.Projects;
 
            _profileDetails.Update(profileDetails);
            return RedirectToAction("index");
        }
        return View();
    }

    [HttpPost]
    public IActionResult NewProfile(ProfileCreateView model)
    {
        if (ModelState.IsValid)
        {
            string uniqueFileName = null;
            if(model.Photo != null)
            {
                string  uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            } 
            
            ProfileDetails newProfileDetails = new ProfileDetails
            {
                Name = model.Name,
                Email = model.Email,
                Department = model.Department,
                Skills = model.Skills,
                Experience = model.Experience,
                Projects = model.Projects,
                PhotoPath = uniqueFileName
            };
            _profileDetails.Add(newProfileDetails);
            return RedirectToAction("details", new { id = newProfileDetails.Id});
        }
        return View();
    }
}