using Symphony.Data.Entities;
using Symphony.ViewModels.Consult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symphony.Services.BackendServices.CourseRegistrationServices
{
   public  interface ICourseRegistrationService
    {


      
         Task<IEnumerable<CourseRegistrationVM>> GetAllCourseRegistrations();
         Task<CourseRegistrationVM> GetCourseRegistrationVM(int courseRegisId);
        Task<IEnumerable<CourseRegistrationWithData>> GetCourseRegistrationWithDatasVM();
        Task<CourseRegistrationVM> CreateCourseRegistration(CreateCourseRegistrationVM courseRegistration);  
        Task<CourseRegistrationVM> UpdateCourseRegistration(UpdateCourseRegistrationVM courseRegistration);
        Task<CourseRegistrationVM> DeleteCourseRegistration(int courseRegistrationId); 
    }
}
        
      


        
        
        

            
    



