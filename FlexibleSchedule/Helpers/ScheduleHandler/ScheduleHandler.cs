using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helpers.ScheduleHandler.Interfaces;
using Models;

namespace Helpers.ScheduleHandler
{
    public class ScheduleHandler 
    {
        private IGetScheduleRepository _ScheduleRepository;

        public ScheduleHandler(IGetScheduleRepository scheduleRepository){
            _ScheduleRepository = scheduleRepository;
        }
        public IEnumerable<IEnumerable<IEnumerable<string>>> GetSchedule<T> (IUserScheduleHandler<T> user) where T: IGroupScheduleHandler{
            List<List<IEnumerable<string>>> returnedSchedule = new List<List<IEnumerable<string>>>();
            List<IEnumerable<IEnumerable<IEnumerable<string>>>> groupsSchedule=new List<IEnumerable<IEnumerable<IEnumerable<string>>>>();
            foreach(IGroupScheduleHandler group in user.Groups){
                groupsSchedule.Add(_ScheduleRepository.GetTimeTableById(group.Code));
            }
            for(int i=0; i<7; i++){
                returnedSchedule.Add(new List<IEnumerable<string>>());
                foreach(IEnumerable<IEnumerable<IEnumerable<string>>> groupSchedule in groupsSchedule){
                    returnedSchedule[i].AddRange(groupSchedule.ToArray()[i]);
                }
                returnedSchedule[i].Sort((x, y)=>{return Convert.ToInt32(x.ToArray()[0])-Convert.ToInt32(y.ToArray()[0]);});
            }
            
            return returnedSchedule;
            
        }
    }
}