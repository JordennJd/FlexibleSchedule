using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helpers.ScheduleHandler.Interfaces
{
    public interface IGetScheduleRepository
    {
        //������� ������� �� �� ������ ���������� ��������� ������, � ������� (��� X ���� X ���� � �����)
        //� ���� � ����� ������ ������� ������ ���� ������������, ������ ���� ����� ����, ���� ����� ����.
        public IEnumerable<IEnumerable<IEnumerable<string>>> GetTimeTableById(int id);
    }
}