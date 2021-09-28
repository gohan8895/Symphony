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


      
         Task<IEnumerable<CourseRegistrationVM>> GetAllCourseRegistrationsAsync();
         Task<CourseRegistrationVM> GetCourseRegistrationVMAsync(int courseRegisId);
        Task<IEnumerable<CourseRegistrationWithData>> GetCourseRegistrationWithDatasVMAsync();
        Task<CourseRegistrationVM> CreateCourseRegistrationAsync(CreateCourseRegistrationVM courseRegistration);  
        Task<CourseRegistrationVM> UpdateCourseRegistrationAsync(UpdateCourseRegistrationVM courseRegistration);
        Task<CourseRegistrationVM> DeleteCourseRegistrationAsync(int courseRegistrationId); 
    }
}
        
      


        
        
        

            
    



