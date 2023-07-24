using System.Diagnostics;
using auth.Helpers;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataTransfersObjects;
using Microsoft.AspNetCore.Http;
using Models;
using auth.Helpers;
using FlexibleSchedule.Services.DataBaseService;
using Helpers.ScheduleHandler;
using Helpers.ScheduleHandler.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.DataBaseService;
namespace Controllers;
[ApiController]
[Route("api/[controller]/[action]")]

public class GroupController : ControllerBase
{
    private readonly JwtService _jwtService;
    private readonly IGroupRepository _groupRepository;
    
    public GroupController(IGroupRepository groupRepository,JwtService jwtService)
    {
        _groupRepository = groupRepository;
        _jwtService = jwtService;
    }
    [HttpGet]
    public IActionResult GetFullTimeTable()
    {
        TimeTableCombiner timeTableCombiner = new TimeTableCombiner();
        var jwt = Request.Cookies["jwt"];

        var token = _jwtService.Verify(jwt);
        
        int userId = int.Parse(token.Issuer);
        List<IEnumerable<IEnumerable<IEnumerable<string>>>> TimeTables=new List<IEnumerable<IEnumerable<IEnumerable<string>>>>();
        foreach (var group in _groupRepository.GetGroupsByUserId(userId).Groups)
        {
            TimeTables.Add(_groupRepository.GetGroupTimeTableById(group.id));
        }
        return Ok(timeTableCombiner.GetSchedule(TimeTables));
    }
    
    [HttpPost]
    public IActionResult CreateGroup(GroupDto groupDto)
    {
        try
        {
            var jwt = Request.Cookies["jwt"];

            var token = _jwtService.Verify(jwt);

            int creatorId = int.Parse(token.Issuer);
            
            Group group = new Group
            {
                Code = groupDto.Code,

                TimeTable = groupDto.timeTable,
                CreatorId = creatorId,
                Users = new List<User>()

            };
            Group group_ = _groupRepository.Create(group);
            return Created("success", group_);
        }
        catch (Exception)
        {
            return Unauthorized();
        }

    }
    
    
    [HttpPost]
    public IActionResult ConnectToGroup(ConnectGroupDto CgroupDto)
    {
        try
        {


            var jwt = Request.Cookies["jwt"];

            var token = _jwtService.Verify(jwt);

            int userId = int.Parse(token.Issuer);


            _groupRepository.ConnectToGroup(CgroupDto, userId);

            return (Ok());
        }
        catch (Exception)
        {
            return Unauthorized();
        }
        
    }

}