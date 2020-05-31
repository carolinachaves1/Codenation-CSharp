using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Models
{
    public class Team
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string MainShirtColor { get; private set; }
        public string SecondaryShirtColor { get; private set; }

        public Player Captain { get; private set; }

        public Team(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            Id = id;
            Name = name;
            CreateDate = createDate;
            MainShirtColor = mainShirtColor;
            SecondaryShirtColor = secondaryShirtColor;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public void SetCreateDate(DateTime createDate)
        {
            CreateDate = createDate;
        }

        public void SetMainShirtColor(String mainShirtColor)
        {
            MainShirtColor = mainShirtColor;
        }

        public void SetSecondaryShirtColor(String secondaryShirtColor)
        {
            SecondaryShirtColor = secondaryShirtColor;
        }

        public void SetCaptain(Player captain)
        {
            Captain = captain;
        }
    }
}
