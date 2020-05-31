using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Models
{
    public class Player
    {
        public long Id { get; private set; }
        public long TeamId { get; private set; }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public int SkillLevel { get; private set; }
        public decimal Salary { get; private set; }

        public Player(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            Id = id;
            TeamId = teamId;
            Name = name;
            BirthDate = birthDate;
            SkillLevel = skillLevel;
            Salary = salary;
        }

        public void SetTeamId(long teamId)
        {
            TeamId = teamId;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
        }

        public void SetSkillLevel(int skillLevel)
        {
            SkillLevel = skillLevel;
        }

        public void SetSalary(decimal salary)
        {
            Salary = salary;
        }
    }
}
