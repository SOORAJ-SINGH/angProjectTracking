using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using angProjectTrackingService2;

namespace angProjectTrackingService2.Models
{
    public class ProjectsRepository
    {
        private static ProjectTrackingDBContext dataContext = new ProjectTrackingDBContext();

        //get all projects 
        public static List<Project> GetAllProjects()
        {
            
            var query = from project in dataContext.Projects
                        select project;
            return query.ToList();
        }
        public static List<Project> SearchProjectsByName(string projectName)
        {
            var query = from project in dataContext.Projects
                        where project.ProjectName.Contains(projectName)
                        select project;
            return query.ToList();
        }

        //get single projects on the basis of the projectId
        public static Project GetProject(int ProjectID)
        {
            var query = from project in dataContext.Projects
                        where project.ProjectID == ProjectID
                        select project;

            return query.SingleOrDefault();
        }


        //Insert Project  
        public static List<Project> InsertProject(Project p)
        {

            dataContext.Projects.Add(p);
            dataContext.SaveChanges();
            return GetAllProjects();
        }


        //Update the Project  on the basis of the projectID
        public static List<Project> UpdateProject(Project p)
        {
            //get the details of the project
            var proj = (from project in dataContext.Projects
                        where project.ProjectID == p.ProjectID
                        select project).SingleOrDefault();

            proj.ProjectName = p.ProjectName;
            proj.StartDate = p.StartDate;
            proj.EndDate = p.EndDate;
            proj.ClientName = p.ClientName;
            dataContext.SaveChanges();
            return GetAllProjects();
        }

        
        //Delete the Project on the basis of the projectID
        public static List<Project> DeleteProject(Project p)
        {
            var proj = (from project in dataContext.Projects
                        where project.ProjectID == p.ProjectID
                        select project).SingleOrDefault();
            dataContext.Projects.Remove(proj);
            dataContext.SaveChanges();
            return GetAllProjects();
        }




    }
}