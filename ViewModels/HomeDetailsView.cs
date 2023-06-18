using System;
using ProfileManagement.Models;
namespace ProfileManagement.ViewModels;

public class HomeDetailsView 
{
    public ProfileDetails ProfileDetails { get; set; }
    public string PageTitle { get; set; }
}